namespace ReloadingBackend.Models;

public class RangeTest
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public List<RoundTest> RoundTests { get; set; }
}

public class RangeTestDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
}