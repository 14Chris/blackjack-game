namespace Domain;

public record Bank
{
    public Hand? Hand { get; private set; }

    public void AddCard(Card card)
    {
        if (Hand is null)
        {
            Hand = new Hand();
        }

        Hand.AddCard(card);
    }
}