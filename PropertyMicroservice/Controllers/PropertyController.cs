using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace PropertyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyContext context;
      
        public PropertyController(PropertyContext ctx)
        {
            this.context = ctx;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Property>))]
        public async Task<IActionResult> GetProperties()
        {
            var query = from item in context.Properties
                        select item;
            var result = await query.ToListAsync();
            return Ok(result);
        }
        [HttpGet("GetById/{Propertyid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Property))]
        public async Task<IActionResult> GetById(int Propertyid)
        {
            var prop = await context.Properties.FindAsync(Propertyid);
            if (prop == null)
              return NotFound();

            return Ok(prop);
        }
       [HttpGet("GetLocality/{Locality}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Property))]
          public async Task<IActionResult> GetLocality(string Locality)
         {
            try
            {
                var prop = context.Properties.Where(p => p.Locality.Contains(Locality)).ToList();
                return Ok(prop);
            }
            catch
            {
                return BadRequest();
            }
            
        }
      

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> SaveProperty(Property obj)
        {
            context.Properties.Add(obj);
            await context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Property))]
        public async Task<IActionResult> UpdateProperty(Property obj)
        {
            var prop = await context.Properties.FindAsync(obj.Propertyid);
            if (prop == null)
                return NotFound();

           
            prop.Budget = obj.Budget;
            prop.PropertyType = obj.PropertyType;
            prop.Locality = obj.Locality;
            await context.SaveChangesAsync();
            return Ok(prop);
        }

        [HttpDelete("{Propertyid}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Deleteproperty(int Propertyid)
        {
            var prop = await context.Properties.FindAsync(Propertyid);
            if (prop == null)
                return NotFound();
            context.Properties.Remove(prop);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
