using CommandLine;

public class Options
{
    [Option('a', "add", Required = false, HelpText = "Új adatok hozzáadása.")]
    public bool Add { get; set; }

    [Option('l', "list", Required = false, HelpText = "Adatok listázása.")]
    public bool List { get; set; }

    [Option('r', "register", Required = false, HelpText = "Új felhasználó regisztrálása.")]
    public bool Register { get; set; }
    
}