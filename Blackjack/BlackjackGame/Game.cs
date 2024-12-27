using Domain;
using Domain.ValueObjects;

namespace BlackjackGame;

public class Game
{
    public void PlayGame()
    {
        Console.WriteLine("Welcome to Lenfant Casino!");

        bool isNumberOfPlayersValid = false;
        var numberOfPlayers = 0;

        while (!isNumberOfPlayersValid)
        {
            Console.WriteLine("Number of players (1-7) ?");
            var enteredKey = Console.ReadKey();

            isNumberOfPlayersValid = Int32.TryParse(enteredKey.KeyChar.ToString(), out int result);

            if (isNumberOfPlayersValid && result >= 1 && result <= 7)
            {
                numberOfPlayers = result;
            }
        }

        var hands = new List<Hand>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Player player = new Player(i + 1);
            
            hands.Add(new Hand(player));
        }

        Deck deck = new Deck();

        var round = new Round(hands, deck);

        // Init cards (2 for players, 1 for bank)
        round.InitCards();

        Console.WriteLine($"Bank cards:");

        foreach (var card in round.Bank.Hand!.Cards)
        {
            Console.WriteLine($"{card.Value.Value} - {card.Value.Type} {card.Color}");
        }

        foreach (var hand in round.Hands)
        {
            PlayerHandActions(hand, round);
        }

        round.DrawCardBank();

        round.FinishRound();

        Console.WriteLine("Bank cards:");

        foreach (var card in round.Bank.Hand!.Cards)
        {
            Console.WriteLine($"{card.Value.Value} - {card.Value.Type} {card.Color}");
        }

        Console.WriteLine($"Bankhand: {round.Bank.Hand!.Value}");

        foreach (var hand in round.Hands)
        {
            Console.WriteLine($"Player {hand.Player.Position} cards:");

            foreach (var card in hand.Cards)
            {
                Console.WriteLine($"{card.Value.Value} - {card.Value.Type} {card.Color}");
            }

            Console.WriteLine($"Player {hand.Player.Position} hand: {hand.Value}");

            if (hand.Value == round.Bank.Hand!.Value)
            {
                Console.WriteLine($"Player {hand.Player.Position} draw!");
            }
            else if (hand.Value > round.Bank.Hand!.Value && !hand!.IsBusted ||
                     round.Bank.Hand!.IsBusted)
            {
                Console.WriteLine($"Player {hand.Player.Position} wins!");
            }
            else
            {
                Console.WriteLine($"Player {hand.Player.Position} loses!");
            }
        }
    }

    private void PlayerHandActions(Hand hand, Round round)
    {
        while (true)
        {
            Console.WriteLine($"Player {hand.Player.Position} cards:");

            foreach (var card in hand.Cards)
            {
                Console.WriteLine($"{card.Value.Value} - {card.Value.Type} {card.Color}");
            }

            Console.WriteLine($"Player {hand.Player.Position} hand: {hand.Value}");

            var isActionKeyValidInt = false;
            HandAction chosenAction = HandAction.Stand;

            while (!isActionKeyValidInt)
            {
                Console.WriteLine("Possible actions for player 1: ");

                foreach (var action in hand.AvailableActions)
                {
                    Console.WriteLine($"{action.Name} - {action.Key}");
                }

                var enteredKey = Console.ReadKey();

                isActionKeyValidInt = Int32.TryParse(enteredKey.KeyChar.ToString(), out int result) &&
                                      HandAction.AllActions.Any(a => a.Key == result);

                chosenAction = HandAction.AllActions.First(a => a.Key == result);
            }

            if (chosenAction == HandAction.Draw)
            {
                hand.AddCard(round.DrawCard());
            }

            if (chosenAction == HandAction.Stand)
            {
                return;
            }

            if (chosenAction == HandAction.Split)
            {
                //TODO: Create a new hand for the player

                var lastCard = hand.Cards.Last();
                hand.Cards.Remove(lastCard);

                var indexOfSplitedHand = round.Hands.IndexOf(hand);
                
                var newHand = new Hand(hand.Player);
                newHand.AddCard(lastCard);
                
                round.Hands.Insert(indexOfSplitedHand + 1, newHand);
                
                return;
            }

            if (chosenAction == HandAction.Double)
            {
                hand.AddCard(round.DrawCard());
                return;
            }

            if (hand.IsBusted)
            {
                Console.WriteLine($"Player {hand.Player.Position} is busted!");
                return;
            }
        }
    }
}