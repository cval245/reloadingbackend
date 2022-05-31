namespace ReloadingBackend.Models;

public class Bullet
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Round> Rounds { get; set; }
}

public class BulletDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}