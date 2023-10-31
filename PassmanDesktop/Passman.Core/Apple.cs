namespace Passman.Core;

public class Apple
{
    // Cretae an Apple class
    // Create a constructor
    // Create a property
    // Create a method
    
    public string Color { get; set; }
    public string Variety { get; set; }
    public string Size { get; set; }
    
    public Apple(string color, string variety, string size)
    {
        Color = color;
        Variety = variety;
        Size = size;
    }
    
    public string GetDescription()
    {
        return $"This is a {Size} {Color} {Variety} apple.";
    }
}