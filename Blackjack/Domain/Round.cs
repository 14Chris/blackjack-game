namespace Domain;

public sealed class Round
{
    public List<Hand> Hands { get; private set; }

    public Bank Bank { get; private set; }

    private Deck Deck { get; set; }

    public Round(List<Hand> hands, Deck deck)
    {
        Hands = hands;
        Bank = new Bank();
        Deck = deck;
    }

    /// <summary>
    /// Init cards for all players and bank
    /// Player: 2 cards each, one before the bank, one after
    /// Bank: 1 card
    /// </summary>
    public void InitCards()
    {
        foreach (var hand in Hands)
        {
            hand.AddCard(Deck.DrawCard());
        }

        Bank.AddCard(Deck.DrawCard());

        foreach (var hand in Hands)
        {
            hand.AddCard(Deck.DrawCard());
        }
    }

    public void DrawCardBank()
    {
        while (Bank.Hand!.Value < 17)
        {
            Bank.AddCard(Deck.DrawCard());
        }
    }

    public Card DrawCard()
    {
        return Deck.DrawCard();
    }

    public void FinishRound()
    {
    }
}