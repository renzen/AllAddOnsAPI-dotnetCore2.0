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
       
      [Authorize]
        public class AddOnController : Controller
    {

        private readonly addOnContext  _context;

        public AddOnController(addOnContext context)
        {
            _context = context;
        }

          // GET api/values
        [HttpGet]
        [Route("api/AllAddOns")]
        
         public async Task<IActionResult> GetAll()  {  
            // fetch all contact records  
            var AddOnlist = await _context.AllAddOns.ToListAsync(); 
            if (AddOnlist == null) {

                return NotFound();

                }
                
            return Ok(AddOnlist);
        }  

          // GET api/values/id
        [HttpGet("{id}")]
        [Route("api/addOn/{id}")]
      public IActionResult GetById(Int64 id) {  
            // filter contact records by contact id  
            var addOn = _context.AllAddOns.FirstOrDefault(t => t.Id == id);
            if (addOn == null) {  
                return NotFound();  
            }  
            return new ObjectResult(addOn);  
        }  

        // POST/ADD api/values
        [HttpPost]
        [Route("api/addAddOn")]
            public async Task<IActionResult> Post([FromBody] AddOns item)
            {
            if(ModelState.IsValid){

            await _context.AddAsync(item).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            return BadRequest(ModelState);

            //return Ok(item);
            return Ok( new { message= "Add-on successfully added."});
            }

            // PUT/EDIT/UPDATE api/values/5
        [HttpPut("{id}")]  
        [Route("api/updateAddOn/{id}")]  
            public async Task<IActionResult> Update(long id, [FromBody] AddOns item) {  
            // set bad request if contact data is not provided in body  
            if (item == null || id == 0) {  
                return BadRequest();  
            }  
             
            var details = await _context.AllAddOns.SingleOrDefaultAsync(t => t.Id == id);
            
            if (details == null) {  
                return NotFound();  
            }  

            details.AddOnName = item.AddOnName; 
            details.Price = item.Price; 
            details.PromoDescription = item.PromoDescription;
            details.GroupId = item.GroupId;
            details.IsPromoRecurring = item.IsPromoRecurring;
            details.RecurringPromoId = item.RecurringPromoId;
            details.Spiel = item.Spiel;
            details.UpdatedAt= DateTime.Now; 

            if(await _context.SaveChangesAsync()> 0)
            {
                return Ok(new { message = "Hi Renzen Add on is updated successfully.", details });
            }
            

            return Ok(new {  
                message = "failed." 
            });
           
        }

     // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/deleteAddOn/{id}")]
        public IActionResult Delete(long id)
     
        {
            var addon = _context.AllAddOns.FirstOrDefault(t => t.Id == id);
            if (addon == null)
            {
                return NotFound();
            }

            _context.AllAddOns.Remove(addon);
            _context.SaveChanges();
            return Ok( new { message= "Add-on is deleted successfully."});
        }

    }

}