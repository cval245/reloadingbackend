using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;
namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class RangeTestController : ControllerBase
{
 [HttpGet(Name = "GetRangeTests")]
     public IEnumerable<RangeTestDto> Get()
     {
         using var db = new DatabaseContext();
         var rangeTests = from b in db.RangeTests
             select ConvertToDto(b);
         return rangeTests.ToList();
     }
 
     [HttpPost(Name = "PostRangeTests")]
     public ActionResult Post([FromBody] RangeTestDto value)
     {
         using var db = new DatabaseContext();
         var rangeTest = new RangeTest()
         {
             Id = 0,
             Date = value.Date,
         };
         db.Add(rangeTest);
         db.SaveChanges();
         return Ok(ConvertToDto(rangeTest));
     }
 
     [HttpPut("{id}", Name = "PutRangeTests")]
     public ActionResult Put(int id, [FromBody] RangeTestDto value)
     {
         if (id != value.Id)
         {
             return BadRequest();
         }
 
         using var db = new DatabaseContext();
         var rangeTest = db.RangeTests.Find(value.Id);
         if (rangeTest == null)
         {
             return BadRequest();
         }
 
         rangeTest.Date= value.Date;
         db.SaveChanges();
 
 
         return Ok(ConvertToDto(rangeTest));
     }
 
     [HttpDelete("{id}", Name = "RangeTestDelete")]
     public ActionResult Delete(int id)
     {
         using var db = new DatabaseContext();
         var rangeTest = db.RangeTests.Find(id);
         if (rangeTest == null)
         {
             return BadRequest();
         }
 
         db.RangeTests.Remove(rangeTest);
         db.SaveChanges();
         return NoContent();
     }
 
     private bool RangeTestExists(long id)
     {
         using var db = new DatabaseContext();
         return db.RangeTests.Any(e => e.Id == id);
     }
 
     private static RangeTestDto ConvertToDto(RangeTest rangeTest)
     {
         return new RangeTestDto()
         {
             Id = rangeTest.Id,
             Date = rangeTest.Date,
         };
     }   
}