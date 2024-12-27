using Domain.ValueObjects;

namespace Domain;

public sealed class Hand
{
    public int Value
    {
        get
        {
            return Cards.Sum(c => c.Value.Value);
        }
    }
    
    public Player? Player { get; }
    
    public List<Card> Cards { get; }

    public bool IsBusted => Value > 21;

    public bool IsBlackjack => Value == 21 && Cards.Count == 2;

    public List<HandAction> AvailableActions
    {
        get
        {
            var actions = new List<HandAction> { HandAction.Stand };

            if (!IsBlackjack)
            {
                actions.Add(HandAction.Draw);
            }

            if (Cards.Count == 2 && Cards[0].Value == Cards[1].Value)
            {
                actions.Add(HandAction.Split);
            }

            if (Cards.Count == 2 && !IsBlackjack)
            {
                actions.Add(HandAction.Double);
            }

            return actions;
        }
    }

    public Hand()
    {
        Cards = new List<Card>();
    }
    
    public Hand(Player player)
    {
        Cards = new List<Card>();
        Player = player;
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
    }
}