using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatShelter.Data;
using CatShelter.Models;
using static CatShelter.Dtos.AdoptionDto;

namespace CatShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdoptionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Adoptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdoptionReadIncludeNamesDto>>> GetAdoptions()
        {
            
            return await _context.Adoptions
                .Include(c => c.Cat)
                .Include(u => u.User)
                .Select(a => new AdoptionReadIncludeNamesDto(a.Id, a.UserId, a.User.FirstName + " " + a.User.LastName, a.CatId, a.Cat.Name, a.Description, a.AdoptionDate))
                .ToListAsync();
        }

        // GET: api/Adoptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adoption>> GetAdoption(int id)
        {
            var adoption = await _context.Adoptions.FindAsync(id);

            if (adoption == null)
            {
                return NotFound();
            }

            return adoption;
        }

        // PUT: api/Adoptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoption(int id, Adoption adoption)
        {
            if (id != adoption.Id)
            {
                return BadRequest();
            }

            _context.Entry(adoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adoptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdoptionReadDto>> CreateAdoption(AdoptionCreateDto dto)
        {
            var adoption = new Adoption { UserId = dto.UserId, CatId = dto.CatId, Description = dto.Description, AdoptionDate = dto.AdoptionDate };
            _context.Adoptions.Add(adoption);
            await _context.SaveChangesAsync();

            return Ok(new AdoptionReadDto(adoption.Id, adoption.UserId, adoption.CatId, adoption.Description, adoption.AdoptionDate));
        }

        // DELETE: api/Adoptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoption(int id)
        {
            var adoption = await _context.Adoptions.FindAsync(id);
            if (adoption == null)
            {
                return NotFound();
            }

            _context.Adoptions.Remove(adoption);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdoptionExists(int id)
        {
            return _context.Adoptions.Any(e => e.Id == id);
        }
    }
}
