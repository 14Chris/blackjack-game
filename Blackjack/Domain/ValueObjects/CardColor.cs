namespace Domain.ValueObjects;

public record CardColor
{
    public static readonly CardColor Heart = new("HEART", "RED");
    public static readonly CardColor Diamond = new("DIAMOND", "RED");
    public static readonly CardColor Club = new("CLUB", "BLACK");
    public static readonly CardColor Spade = new("SPADE", "BLACK");
    public string Name { get; }
    public string Color { get; }

    public static List<CardColor> AllColors => new() { Heart, Diamond, Club, Spade };

    private CardColor(string name, string color)
    {
        Name = name;
        Color = color;
    }
}