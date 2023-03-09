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
    public class Tipo_documentosController : ControllerBase
    {
        private readonly bolsa_de_empleo_apiContext _context;

        public Tipo_documentosController(bolsa_de_empleo_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tipo_documentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_documentos>>> GetTipo_documentos()
        {
            return await _context.Tipo_documentos.ToListAsync();
        }

        // GET: api/Tipo_documentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_documentos>> GetTipo_documentos(string id)
        {
            var tipo_documentos = await _context.Tipo_documentos.FindAsync(id);

            if (tipo_documentos == null)
            {
                return NotFound();
            }

            return tipo_documentos;
        }

        // PUT: api/Tipo_documentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_documentos(string id, Tipo_documentos tipo_documentos)
        {
            if (id != tipo_documentos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipo_documentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_documentosExists(id))
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

        // POST: api/Tipo_documentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipo_documentos>> PostTipo_documentos(Tipo_documentos tipo_documentos)
        {
            _context.Tipo_documentos.Add(tipo_documentos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tipo_documentosExists(tipo_documentos.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipo_documentos", new { id = tipo_documentos.Id }, tipo_documentos);
        }

        // DELETE: api/Tipo_documentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_documentos(string id)
        {
            var tipo_documentos = await _context.Tipo_documentos.FindAsync(id);
            if (tipo_documentos == null)
            {
                return NotFound();
            }

            _context.Tipo_documentos.Remove(tipo_documentos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tipo_documentosExists(string id)
        {
            return _context.Tipo_documentos.Any(e => e.Id == id);
        }
    }
}
