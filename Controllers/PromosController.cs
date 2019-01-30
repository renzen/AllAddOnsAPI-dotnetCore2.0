using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllAddOnsAPI.Models;
using Microsoft.AspNetCore.Authorization;

    
      

namespace AllAddOnsAPI.Controllers
{
    [Authorize (Roles ="Administrator")]
        public class PromosController : Controller
    {
        private readonly addOnContext  _context;

        public PromosController(addOnContext context)
        {
            _context = context;
        }

          // GET api/values
         [HttpGet]
        [Route("api/Promos")]
         public async Task<IActionResult> GetAll()  {  
            // fetch all contact records  
            var Promolist = await _context.Promos.ToListAsync(); 
            if (Promolist == null) {

                return NotFound();

                }
                
            return Ok(Promolist);
        }  

          // GET api/values/id
        [HttpGet("{id}")]
        [Route("api/promo/{id}")]
      public IActionResult GetById(Int64 id) {  
            // filter contact records by contact id  
            var promo = _context.Promos.FirstOrDefault(t => t.Id == id);
            if (promo == null) {  
                return NotFound();  
            }  
            return new ObjectResult(promo);  
        }  

        // POST/ADD api/values
        [HttpPost]
        [Route("api/addPromo")]
            public async Task<IActionResult> Post([FromBody] Promos item)
            {
            if(ModelState.IsValid){

            await _context.AddAsync(item).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            return BadRequest(ModelState);

            //return Ok(item);
            return Ok( new { message= "Promo successfully added."});
            }

            // PUT/EDIT/UPDATE api/values/5
        [HttpPut("{id}")]  
        [Route("api/updatePromo/{id}")]  
            public async Task<IActionResult> Update(long id, [FromBody] Promos item) {  
            // set bad request if contact data is not provided in body  
            if (item == null || id == 0) {  
                return BadRequest();  
            }  
             
            var details = await _context.Promos.SingleOrDefaultAsync(t => t.Id == id);
            
            if (details == null) {  
                return NotFound();  
            }  

            details.PromID = item.PromID;
            details.Promoname = item.Promoname; 
            details.Price = item.Price; 
            details.PromoDescription = item.PromoDescription;
            details.GroupId = item.GroupId;
            details.IsPromoRecurring = item.IsPromoRecurring;
            details.RecurringPromoId = item.RecurringPromoId;
            details.Spiel = item.Spiel;
            details.UpdatedAt= DateTime.Now; 

            if(await _context.SaveChangesAsync()> 0)
            {
                return Ok(new { message = "Hi Renzen Promo is updated successfully.", details });
            }
            

            return Ok(new {  
                message = "failed." 
            });
           
        }

     // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/deletePromo/{id}")]
        public IActionResult Delete(long id)
     
        {
            var promo = _context.Promos.FirstOrDefault(t => t.Id == id);
            if (promo == null)
            {
                return NotFound();
            }

            _context.Promos.Remove(promo);
            _context.SaveChanges();
            return Ok( new { message= "Promo is deleted successfully."});
        }

    }

}