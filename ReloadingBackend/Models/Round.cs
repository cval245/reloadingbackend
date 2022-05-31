using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReloadingBackend.Models;

public class Round
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual RoundTest RoundTest { get; set; }

    public int PowderId { get; set; }
    public virtual Powder Powder { get; set; }

    public int BulletId { get; set; }
    public virtual Bullet Bullet { get; set; }

    public int PrimerId { get; set; }
    public virtual Primer Primer { get; set; }
}

public class RoundDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int PowderId { get; set; }
    public int BulletId { get; set; }
    public int PrimerId { get; set; }
}