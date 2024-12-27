namespace Domain;

public record Player
{
    public int Position { get; }
    
    //TODO: Handle multiple hands for a player : case of Split
    public Hand? Hand { get; private set; }
    
    public Player(int position)
    {
        Position = position;
    }
}