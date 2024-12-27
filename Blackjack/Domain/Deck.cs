using Domain.ValueObjects;

namespace Domain;

public sealed record Deck
{
    private List<Card> Cards { get; set; }

    public Deck()
    {
        Cards = new List<Card>();
        
        foreach(var cardColor in CardColor.AllColors)
        {
            foreach(var cardValue in CardValue.AllValues)
            {
                Cards.Add(new Card(cardColor, cardValue));
            }
        }

        Suffle();
    }
    
    /// <summary>
    /// Draw a card from the deck.
    /// </summary>
    /// <returns>First card in the deck.</returns>
    public Card DrawCard()
    {
        //TODO: If no cards left in deck, throw exception
        var card = Cards.First();
        Cards.Remove(card);
        return card;
    }

    /// <summary>
    /// Suffle the deck cards.
    /// </summary>
    private void Suffle()
    {
        Random rand = new Random();
        
        for (int i = 0; i < Cards.Count; i++)
        {
             
            // Random for remaining positions.
            int r = i + rand.Next(52 - i);
             
            //swapping the elements
            (Cards[r], Cards[i]) = (Cards[i], Cards[r]);
        }
    }
}