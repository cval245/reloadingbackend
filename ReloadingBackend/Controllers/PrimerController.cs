using Microsoft.AspNetCore.Mvc;
using ReloadingBackend.Models;
namespace ReloadingBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PrimerController : ControllerBase
{
     [HttpGet(Name = "GetPrimers")]
         public IEnumerable<PrimerDto> Get()
         {
             using var db = new DatabaseContext();
             var primers = from b in db.Primers
                 select ConvertToDto(b);
             return primers.ToList();
         }
     
         [HttpPost(Name = "PostPrimers")]
         public ActionResult Post([FromBody] PrimerDto value)
         {
             using var db = new DatabaseContext();
             var primer = new Primer()
             {
                 Id = 0,
                 Name = value.Name,
             };
             db.Add(primer);
             db.SaveChanges();
             return Ok(ConvertToDto(primer));
         }
     
         [HttpPut("{id}", Name = "PutPrimers")]
         public ActionResult Put(int id, [FromBody] PrimerDto value)
         {
             if (id != value.Id)
             {
                 return BadRequest();
             }
     
             using var db = new DatabaseContext();
             var primer = db.Primers.Find(value.Id);
             if (primer == null)
             {
                 return BadRequest();
             }
     
             primer.Name = value.Name;
             db.SaveChanges();
     
     
             return Ok(ConvertToDto(primer));
         }
     
         [HttpDelete("{id}", Name = "PrimerDelete")]
         public ActionResult Delete(int id)
         {
             using var db = new DatabaseContext();
             var primer = db.Primers.Find(id);
             if (primer == null)
             {
                 return BadRequest();
             }
     
             db.Primers.Remove(primer);
             db.SaveChanges();
             return NoContent();
         }
     
         private bool PrimerExists(long id)
         {
             using var db = new DatabaseContext();
             return db.Primers.Any(e => e.Id == id);
         }

         private static PrimerDto ConvertToDto(Primer primer)
         {
             return new PrimerDto()
             {
                 Id = primer.Id,
                 Name = primer.Name,
             };
         }
}