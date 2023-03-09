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
    public class CiudadanosController : ControllerBase
    {
        private readonly bolsa_de_empleo_apiContext _context;

        public CiudadanosController(bolsa_de_empleo_apiContext context)
        {
            _context = context;
        }

        // GET: api/Ciudadanos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudadanos>>> GetCiudadanos()
        {
            return await _context.Ciudadanos.ToListAsync();
        }

        // GET: api/Ciudadanos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudadanos>> GetCiudadanos(int id)
        {
            var ciudadanos = await _context.Ciudadanos.FindAsync(id);

            if (ciudadanos == null)
            {
                return NotFound();
            }

            return ciudadanos;
        }

        // PUT: api/Ciudadanos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCiudadanos(int id, Ciudadanos ciudadanos)
        {
            if (id != ciudadanos.Id)
            {
                return BadRequest();
            }

            _context.Entry(ciudadanos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadanosExists(id))
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

        // POST: api/Ciudadanos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ciudadanos>> PostCiudadanos(Ciudadanos ciudadanos)
        {
            _context.Ciudadanos.Add(ciudadanos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCiudadanos", new { id = ciudadanos.Id }, ciudadanos);
        }

        // DELETE: api/Ciudadanos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudadanos(int id)
        {
            var ciudadanos = await _context.Ciudadanos.FindAsync(id);
            if (ciudadanos == null)
            {
                return NotFound();
            }

            _context.Ciudadanos.Remove(ciudadanos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CiudadanosExists(int id)
        {
            return _context.Ciudadanos.Any(e => e.Id == id);
        }
    }
}
