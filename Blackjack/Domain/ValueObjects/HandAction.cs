namespace Domain.ValueObjects;

public sealed record HandAction
{
    public static readonly HandAction Double = new("DOUBLE", 1);
    public static readonly HandAction Split = new("SPLIT", 2);
    public static readonly HandAction Draw = new("DRAW", 3);
    public static readonly HandAction Stand = new("STAND", 4);
    
    public static List<HandAction> AllActions => new() { Double, Split, Draw, Stand };
    public string Name { get; }
    public int Key { get; }

    private HandAction(string name, int key)
    {
        Name = name;
        Key = key;
    }
}