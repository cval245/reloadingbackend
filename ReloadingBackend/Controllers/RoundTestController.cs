using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;

namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class RoundTestController: ControllerBase
{
 [HttpGet(Name = "GetRoundTests")]
     public IEnumerable<RoundTestDto> Get()
     {
         using var db = new DatabaseContext();
         var rounds = from b in db.RoundTests
             select ConvertToDto(b);
         return rounds.ToList();
     }
 
     [HttpPost(Name = "PostRoundTests")]
     public ActionResult Post([FromBody] RoundTestDto value)
     {
         using var db = new DatabaseContext();
         var roundTest = new RoundTest()
         {
             Id = 0,
             Velocity = value.Velocity,
             RoundId = value.RoundId,
         };
         db.Add(roundTest);
         db.SaveChanges();
         return Ok(ConvertToDto(roundTest));
     }
 
     [HttpPut("{id}", Name = "PutRoundTests")]
     public ActionResult Put(int id, [FromBody] RoundTestDto value)
     {
         if (id != value.Id)
         {
             return BadRequest();
         }
 
         using var db = new DatabaseContext();
         var roundTest = db.RoundTests.Find(value.Id);
         if (roundTest == null)
         {
             return BadRequest();
         }
 
         roundTest.RoundId = value.RoundId;
         roundTest.Velocity = value.Velocity;
         db.SaveChanges();
 
 
         return Ok(ConvertToDto(roundTest));
     }
 
     [HttpDelete("{id}", Name = "RoundTestDelete")]
     public ActionResult Delete(int id)
     {
         using var db = new DatabaseContext();
         var roundTest = db.RoundTests.Find(id);
         if (roundTest == null)
         {
             return BadRequest();
         }
 
         db.RoundTests.Remove(roundTest);
         db.SaveChanges();
         return NoContent();
     }
 
     private bool RoundExists(long id)
     {
         using var db = new DatabaseContext();
         return db.RoundTests.Any(e => e.Id == id);
     }
 
     private static RoundTestDto ConvertToDto(RoundTest roundTest)
     {
         return new RoundTestDto()
         {
             Id = roundTest.Id,
             RoundId = roundTest.RoundId,
             Velocity = roundTest.Velocity,
         };
     }   
}