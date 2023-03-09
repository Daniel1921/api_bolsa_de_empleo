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
    public class Aplicacion_vacantesController : ControllerBase
    {
        private readonly bolsa_de_empleo_apiContext _context;

        public Aplicacion_vacantesController(bolsa_de_empleo_apiContext context)
        {
            _context = context;
        }

        // GET: api/Aplicacion_vacantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacion_vacantes>>> GetAplicacion_vacantes()
        {
            return await _context.Aplicacion_vacantes.ToListAsync();
        }

        // GET: api/Aplicacion_vacantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacion_vacantes>> GetAplicacion_vacantes(int id)
        {
            var aplicacion_vacantes = await _context.Aplicacion_vacantes.FindAsync(id);

            if (aplicacion_vacantes == null)
            {
                return NotFound();
            }

            return aplicacion_vacantes;
        }

        // PUT: api/Aplicacion_vacantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacion_vacantes(int id, Aplicacion_vacantes aplicacion_vacantes)
        {
            if (id != aplicacion_vacantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicacion_vacantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Aplicacion_vacantesExists(id))
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

        // POST: api/Aplicacion_vacantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aplicacion_vacantes>> PostAplicacion_vacantes(Aplicacion_vacantes aplicacion_vacantes)
        {
            _context.Aplicacion_vacantes.Add(aplicacion_vacantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacion_vacantes", new { id = aplicacion_vacantes.Id }, aplicacion_vacantes);
        }

        // DELETE: api/Aplicacion_vacantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacion_vacantes(int id)
        {
            var aplicacion_vacantes = await _context.Aplicacion_vacantes.FindAsync(id);
            if (aplicacion_vacantes == null)
            {
                return NotFound();
            }

            _context.Aplicacion_vacantes.Remove(aplicacion_vacantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Aplicacion_vacantesExists(int id)
        {
            return _context.Aplicacion_vacantes.Any(e => e.Id == id);
        }
    }
}
