namespace Domain.ValueObjects;

public record CardValue
{
    public static readonly CardValue Ace = new("ACE", 11);
    public static readonly CardValue King = new("KING", 10);
    public static readonly CardValue Queen = new("QUEEN", 10);
    public static readonly CardValue Jack = new("JACK", 10);
    public static readonly CardValue Ten = new("TEN", 10);
    public static readonly CardValue Nine = new("NINE", 9);
    public static readonly CardValue Eight = new("EIGHT", 8);
    public static readonly CardValue Seven = new("SEVEN", 7);
    public static readonly CardValue Six = new("SIX", 6);
    public static readonly CardValue Five = new("FIVE", 5);
    public static readonly CardValue Four = new("FOUR", 4);
    public static readonly CardValue Three = new("THREE", 3);
    public static readonly CardValue Two = new("TWO", 2);

    public static List<CardValue> AllValues => new()
    {
        Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two
    };
    
    public string Type { get; }

    public int Value { get; }

    private CardValue(string type, int value)
    {
        Type = type;
        Value = value;
    }
}