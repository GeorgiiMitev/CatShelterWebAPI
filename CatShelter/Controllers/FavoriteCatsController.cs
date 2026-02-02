using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatShelter.Data;
using CatShelter.Models;
using static CatShelter.Dtos.FavoriteCatDto;

namespace CatShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCatsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteCatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteCats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteCatReadIncludeNamesDto>>> GetFavoriteCats()
        {
            return await _context.FavoriteCats
                .Include(c => c.Cat)
                .Include(u => u.User)
                .Select(fc => new FavoriteCatReadIncludeNamesDto(fc.Id, fc.UserId, fc.User.FirstName + " " + fc.User.LastName, fc.CatId, fc.Cat.Name))
                .ToListAsync();
        }

        // GET: api/FavoriteCats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteCat>> GetFavoriteCat(int id)
        {
            var favoriteCat = await _context.FavoriteCats.FindAsync(id);

            if (favoriteCat == null)
            {
                return NotFound();
            }

            return favoriteCat;
        }

        // PUT: api/FavoriteCats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteCat(int id, FavoriteCat favoriteCat)
        {
            if (id != favoriteCat.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteCat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteCatExists(id))
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

        // POST: api/FavoriteCats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteCatReadDto>> CreateFavoriteCat(FavoriteCatCreateDto dto)
        {
            var favoriteCat = new FavoriteCat { UserId = dto.UserId, CatId = dto.CatId };
            _context.FavoriteCats.Add(favoriteCat);
            await _context.SaveChangesAsync();

            return Ok(new FavoriteCatReadDto(favoriteCat.Id, favoriteCat.UserId, favoriteCat.CatId));
        }

        // DELETE: api/FavoriteCats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteCat(int id)
        {
            var favoriteCat = await _context.FavoriteCats.FindAsync(id);
            if (favoriteCat == null)
            {
                return NotFound();
            }

            _context.FavoriteCats.Remove(favoriteCat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteCatExists(int id)
        {
            return _context.FavoriteCats.Any(e => e.Id == id);
        }
    }
}
