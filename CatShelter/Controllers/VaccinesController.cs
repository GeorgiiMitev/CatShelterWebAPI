using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatShelter.Data;
using CatShelter.Models;
using static CatShelter.Dtos.VaccineDto;

namespace CatShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VaccinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineReadDto>>> GetVaccines()
        {
            return await _context.Vaccines.Select(v => new VaccineReadDto(v.Id, v.Name, v.Description)).ToListAsync();
        }

        // GET: api/Vaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);

            if (vaccine == null)
            {
                return NotFound();
            }

            return vaccine;
        }

        // PUT: api/Vaccines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccine(int id, Vaccine vaccine)
        {
            if (id != vaccine.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineExists(id))
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

        // POST: api/Vaccines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineReadDto>> CreateVaccine(VaccineCreateDto dto)
        {
            var vaccine = new Vaccine { Name = dto.Name, Description = dto.Description };
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync();

            return Ok(new VaccineReadDto(vaccine.Id, vaccine.Name, vaccine.Description));
        }

        // DELETE: api/Vaccines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            _context.Vaccines.Remove(vaccine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineExists(int id)
        {
            return _context.Vaccines.Any(e => e.Id == id);
        }
    }
}
