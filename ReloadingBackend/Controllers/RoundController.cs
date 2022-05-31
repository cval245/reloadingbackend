using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;

namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class RoundController : ControllerBase
{
    [HttpGet(Name = "GetRounds")]
    public IEnumerable<RoundDto> Get()
    {
        using var db = new DatabaseContext();
        var rounds = from b in db.Rounds
            select ConvertToDto(b);
        return rounds.ToList();
    }

    [HttpPost(Name = "PostRounds")]
    public ActionResult Post([FromBody] RoundDto value)
    {
        using var db = new DatabaseContext();
        var round = new Round()
        {
            Id = 0,
            Name = value.Name,
            PowderId = value.PowderId,
            PrimerId = value.PrimerId,
            BulletId = value.BulletId,
        };
        db.Add(round);
        db.SaveChanges();
        return Ok(ConvertToDto(round));
    }

    [HttpPut("{id}", Name = "PutRounds")]
    public ActionResult Put(int id, [FromBody] RoundDto value)
    {
        if (id != value.Id)
        {
            return BadRequest();
        }

        using var db = new DatabaseContext();
        var round = db.Rounds.Find(value.Id);
        if (round == null)
        {
            return BadRequest();
        }

        round.Name = value.Name;
        round.PowderId = value.PowderId;
        round.BulletId = value.BulletId;
        round.PrimerId = value.PrimerId;
        db.SaveChanges();


        return Ok(ConvertToDto(round));
    }

    [HttpDelete("{id}", Name = "RoundDelete")]
    public ActionResult Delete(int id)
    {
        using var db = new DatabaseContext();
        var round = db.Rounds.Find(id);
        if (round == null)
        {
            return BadRequest();
        }

        db.Rounds.Remove(round);
        db.SaveChanges();
        return NoContent();
    }

    private bool RoundExists(long id)
    {
        using var db = new DatabaseContext();
        return db.Rounds.Any(e => e.Id == id);
    }

    private static RoundDto ConvertToDto(Round round)
    {
        return new RoundDto()
        {
            Id = round.Id,
            PowderId = round.PowderId,
            BulletId = round.BulletId,
            PrimerId = round.PrimerId,
            Name = round.Name,
        };
    }
}