namespace ReloadingBackend.Models;

public class Primer
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Round> Rounds { get; set; }
}

public class PrimerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}