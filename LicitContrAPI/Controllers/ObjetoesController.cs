using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicitContrAPI.Models;

namespace LicitContrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoesController : ControllerBase
    {
        private readonly BancoDadosCLContext _context;

        public ObjetoesController(BancoDadosCLContext context)
        {
            _context = context;
        }

        // GET: api/Objetoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objeto>>> GetObjetos()
        {
          if (_context.Objetos == null)
          {
              return NotFound();
          }
            return await _context.Objetos.ToListAsync();
        }

        // GET: api/Objetoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objeto>> GetObjeto(int id)
        {
          if (_context.Objetos == null)
          {
              return NotFound();
          }
            var objeto = await _context.Objetos.FindAsync(id);

            if (objeto == null)
            {
                return NotFound();
            }

            return objeto;
        }

        // PUT: api/Objetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjeto(int id, Objeto objeto)
        {
            if (id != objeto.IdObjeto)
            {
                return BadRequest();
            }

            _context.Entry(objeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetoExists(id))
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

        // POST: api/Objetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objeto>> PostObjeto(Objeto objeto)
        {
          if (_context.Objetos == null)
          {
              return Problem("Entity set 'BancoDadosCLContext.Objetos'  is null.");
          }
            _context.Objetos.Add(objeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjeto", new { id = objeto.IdObjeto }, objeto);
        }

        // DELETE: api/Objetoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjeto(int id)
        {
            if (_context.Objetos == null)
            {
                return NotFound();
            }
            var objeto = await _context.Objetos.FindAsync(id);
            if (objeto == null)
            {
                return NotFound();
            }

            _context.Objetos.Remove(objeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjetoExists(int id)
        {
            return (_context.Objetos?.Any(e => e.IdObjeto == id)).GetValueOrDefault();
        }
    }
}
