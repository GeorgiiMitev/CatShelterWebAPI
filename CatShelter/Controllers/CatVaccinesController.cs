using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatShelter.Data;
using CatShelter.Models;
using static CatShelter.Dtos.CatVaccineDto;

namespace CatShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatVaccinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CatVaccinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CatVaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatVaccineReadIncludeNamesDto>>> GetCatVaccines()
        {
            return await _context.CatVaccines
                .Include(c => c.Cat)
                .Include(v => v.Vaccine)
                .Select(cv => new CatVaccineReadIncludeNamesDto(cv.Id, cv.CatId, cv.Cat.Name, cv.VaccineId, cv.Vaccine.Name + " - " + cv.Vaccine.Description)).ToListAsync();
        }

        // GET: api/CatVaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatVaccine>> GetCatVaccine(int id)
        {
            var catVaccine = await _context.CatVaccines.FindAsync(id);

            if (catVaccine == null)
            {
                return NotFound();
            }

            return catVaccine;
        }

        // PUT: api/CatVaccines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatVaccine(int id, CatVaccine catVaccine)
        {
            if (id != catVaccine.Id)
            {
                return BadRequest();
            }

            _context.Entry(catVaccine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatVaccineExists(id))
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

        // POST: api/CatVaccines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatVaccineReadDto>> CreateCatVaccine(CatVaccineCreateDto dto)
        {
            var catVaccine = new CatVaccine { CatId = dto.CatId, VaccineId = dto.VaccineId };
            _context.CatVaccines.Add(catVaccine);
            await _context.SaveChangesAsync();

            return Ok(new CatVaccineReadDto(catVaccine.Id, catVaccine.CatId, catVaccine.VaccineId));
        }

        // DELETE: api/CatVaccines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatVaccine(int id)
        {
            var catVaccine = await _context.CatVaccines.FindAsync(id);
            if (catVaccine == null)
            {
                return NotFound();
            }

            _context.CatVaccines.Remove(catVaccine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatVaccineExists(int id)
        {
            return _context.CatVaccines.Any(e => e.Id == id);
        }
    }
}
