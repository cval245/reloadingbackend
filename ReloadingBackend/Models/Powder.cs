namespace ReloadingBackend.Models;

public class Powder
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Round> Rounds { get; set; }
}
public class PowderDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}