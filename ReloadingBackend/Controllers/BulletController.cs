using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;

namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class BulletController : ControllerBase
{
    [HttpGet(Name = "GetBullets")]
    public IEnumerable<BulletDto> Get()
    {
        using var db = new DatabaseContext();
        var bullets = from b in db.Bullets
            select ConvertToDto(b);
        return bullets.ToList();
    }

    [HttpPost(Name = "PostBullets")]
    public ActionResult Post([FromBody] BulletDto value)
    {
        using var db = new DatabaseContext();
        var bullet = new Bullet()
        {
            Id = 0,
            Name = value.Name,
        };
        db.Add(bullet);
        db.SaveChanges();
        return Ok(ConvertToDto(bullet));
    }

    [HttpPut("{id}", Name = "PutBullets")]
    public ActionResult Put(int id, [FromBody] BulletDto value)
    {
        if (id != value.Id)
        {
            return BadRequest();
        }

        using var db = new DatabaseContext();
        var bullet = db.Bullets.Find(value.Id);
        if (bullet == null)
        {
            return BadRequest();
        }

        bullet.Name = value.Name;
        db.SaveChanges();


        return Ok(ConvertToDto(bullet));
    }

    [HttpDelete("{id}", Name = "BulletDelete")]
    public ActionResult Delete(int id)
    {
        using var db = new DatabaseContext();
        var bullet = db.Bullets.Find(id);
        if (bullet == null)
        {
            return BadRequest();
        }

        db.Bullets.Remove(bullet);
        db.SaveChanges();
        return NoContent();
    }

    private bool BulletExists(long id)
    {
        using var db = new DatabaseContext();
        return db.Bullets.Any(e => e.Id == id);
    }

    private static BulletDto ConvertToDto(Bullet bullet)
    {
        return new BulletDto()
        {
            Id = bullet.Id,
            Name = bullet.Name,
        };
    }
}