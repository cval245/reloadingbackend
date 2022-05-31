using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;

namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PowderController : ControllerBase
{
    [HttpGet(Name = "GetPowders")]
        public IEnumerable<PowderDto> Get()
        {
            using var db = new DatabaseContext();
            var powders = from b in db.Powders
                select ConvertToDto(b);
            return powders.ToList();
        }
    
        [HttpPost(Name = "PostPowders")]
        public ActionResult Post([FromBody] PowderDto value)
        {
            using var db = new DatabaseContext();
            var powder = new Powder()
            {
                Id = 0,
                Name = value.Name,
            };
            db.Add(powder);
            db.SaveChanges();
            return Ok(ConvertToDto(powder));
        }
    
        [HttpPut("{id}", Name = "PutPowders")]
        public ActionResult Put(int id, [FromBody] PowderDto value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
    
            using var db = new DatabaseContext();
            var powder = db.Powders.Find(value.Id);
            if (powder == null)
            {
                return BadRequest();
            }
    
            powder.Name = value.Name;
            db.SaveChanges();
    
    
            return Ok(ConvertToDto(powder));
        }
    
        [HttpDelete("{id}", Name = "PowderDelete")]
        public ActionResult Delete(int id)
        {
            using var db = new DatabaseContext();
            var powder = db.Powders.Find(id);
            if (powder == null)
            {
                return BadRequest();
            }
    
            db.Powders.Remove(powder);
            db.SaveChanges();
            return NoContent();
        }
    
        private bool PowderExists(long id)
        {
            using var db = new DatabaseContext();
            return db.Powders.Any(e => e.Id == id);
        }
    
        private static PowderDto ConvertToDto(Powder powder)
        {
            return new PowderDto()
            {
                Id = powder.Id,
                Name = powder.Name,
            };
        }
}