using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bolsa_de_empleo_api.Data;
using bolsa_de_empleo_api.Models;

namespace bolsa_de_empleo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantesController : ControllerBase
    {
        private readonly bolsa_de_empleo_apiContext _context;

        public VacantesController(bolsa_de_empleo_apiContext context)
        {
            _context = context;
        }

        // GET: api/Vacantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacantes>>> GetVacantes()
        {
            return await _context.Vacantes.ToListAsync();
        }

        // GET: api/Vacantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacantes>> GetVacantes(int id)
        {
            var vacantes = await _context.Vacantes.FindAsync(id);

            if (vacantes == null)
            {
                return NotFound();
            }

            return vacantes;
        }

        // PUT: api/Vacantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacantes(int id, Vacantes vacantes)
        {
            if (id != vacantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacantesExists(id))
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

        // POST: api/Vacantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacantes>> PostVacantes(Vacantes vacantes)
        {
            _context.Vacantes.Add(vacantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacantes", new { id = vacantes.Id }, vacantes);
        }

        // DELETE: api/Vacantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacantes(int id)
        {
            var vacantes = await _context.Vacantes.FindAsync(id);
            if (vacantes == null)
            {
                return NotFound();
            }

            _context.Vacantes.Remove(vacantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacantesExists(int id)
        {
            return _context.Vacantes.Any(e => e.Id == id);
        }
    }
}
