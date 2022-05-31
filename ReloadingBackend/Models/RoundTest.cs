namespace ReloadingBackend.Models;

public class RoundTest
{
    public int Id { get; set; }
    public float Velocity { get; set; }

    public int RoundId { get; set; }
    public Round Round { get; set; }
    public int RangeTestId { get; set; } 
    public RangeTest RangeTest { get; set; }
}

public class RoundTestDto
{
    public int Id { get; set; }
    public float Velocity { get; set; }

    public int RoundId { get; set; }
    
    public int RangeTestId { get; set; }
}