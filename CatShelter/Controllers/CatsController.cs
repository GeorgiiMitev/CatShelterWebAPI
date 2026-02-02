using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatShelter.Data;
using CatShelter.Models;
using static CatShelter.Dtos.CatDto;

namespace CatShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatReadIncludeNamesDto>>> GetCats()
        {
            return await _context.Cats.Include(b => b.Breed).Select(c => new CatReadIncludeNamesDto(c.Id, c.Name, c.Age, c.Gender, c.BreedId, c.Breed.Name, c.Description, c.ImageURL)).ToListAsync();
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var cat = await _context.Cats.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
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

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatReadDto>> CreateCat(CatCreateDto dto)
        {
            var cat = new Cat{ Name = dto.Name, Age = dto.Age, Gender = dto.Gender,
                BreedId = dto.BreedId, Description = dto.Description, ImageURL = dto.ImageURL};

            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();

            return Ok(new CatReadDto(cat.Id, cat.Name, cat.Age, cat.Gender, cat.BreedId, cat.Description, cat.ImageURL));
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
