using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly ComputerShopContext _context;

        public ComponentsController(ComputerShopContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.ComponentViewModel>>> GetComponents()
        {
            return await _context.Components
                .Include(c => c.Manufacturer)
                .Include(c => c.ComponentType)
                .Include(c => c.Country)
                .Select(c => new ViewModels.ComponentViewModel 
                { 
                    Id = c.Id,
                    ComponentTypeId = c.ComponentTypeId,
                    Model = c.Model,
                    ManufacturerId = c.ManufacturerId,
                    CountryId = c.CountryId,
                    ReleaseDate = c.ReleaseDate,
                    Characteristics = c.Characteristics,
                    WarrantyInMonths = c.WarrantyInMonths,
                    Description = c.Description,
                    Price = c.Price,

                    ComponentTypeName = c.ComponentType.Name,
                    CountryName = c.Country.Name,
                    ManufacturerName = c.Manufacturer.Name
                })
                .ToListAsync();
        }

        [HttpGet("componentTypes")]
        public async Task<ActionResult<IEnumerable<ComponentType>>> GetComponentTypes()
        {
            return await _context.ComponentTypes.ToListAsync();
        }

        [HttpGet("manufacturers")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Components/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        // PUT: api/Components/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutComponent(Component component)
        {

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                _context.Update(component);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Components.Any(x => x.Id == component.Id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Components
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component component)
        {
            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponent", new { id = component.Id }, component);
        }

        // DELETE: api/Components/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Component>> DeleteComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return component;
        }

        private bool ComponentExists(int id)
        {
            return _context.Components.Any(e => e.Id == id);
        }
    }
}
