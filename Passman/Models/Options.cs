using CommandLine;

public class Options
{
    [Option('a', "add", Required = false, HelpText = "Új adatok hozzáadása.")]
    public bool Add { get; set; }

    [Option('l', "list", Required = false, HelpText = "Adatok listázása.")]
    public bool List { get; set; }

    [Option('r', "register", Required = false, HelpText = "Új felhasználó regisztrálása.")]
    public bool Register { get; set; }
    
    //test option
    [Option('t', "test", Required = false, HelpText = "Tesztelés.")]
    public bool Test { get; set; }
    
    
    // [Option('w', "workdir", Required = false, HelpText = "Working directory módosítása.")]
    // public bool Workdir { get; set; }
    //
    // [Option('d', "delete", Required = false, HelpText = "Working directory alaphelyzetbe állítása.")]
    // public bool Delete { get; set; }
}