using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicitContrAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace LicitContrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly BancoDadosCLContext _context;

        public EntidadesController(BancoDadosCLContext context)
        {
            _context = context;
        }

        // GET: api/Entidades
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Entidade>>> GetEntidades()
        {
          if (_context.Entidades == null)
          {
              return NotFound();
          }
            return await _context.Entidades.ToListAsync();
        }

        // GET: api/Entidades/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Entidade>> GetEntidade(int id)
        {
          if (_context.Entidades == null)
          {
              return NotFound();
          }
            var entidade = await _context.Entidades.FindAsync(id);

            if (entidade == null)
            {
                return NotFound();
            }

            return entidade;
        }

        // PUT: api/Entidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEntidade(int id, Entidade entidade)
        {
            if (id != entidade.IdEntidade)
            {
                return BadRequest();
            }

            _context.Entry(entidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadeExists(id))
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

        // POST: api/Entidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Entidade>> PostEntidade(Entidade entidade)
        {
          if (_context.Entidades == null)
          {
              return Problem("Entity set 'BancoDadosCLContext.Entidades'  is null.");
          }
            _context.Entidades.Add(entidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntidade", new { id = entidade.IdEntidade }, entidade);
        }

        // DELETE: api/Entidades/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEntidade(int id)
        {
            if (_context.Entidades == null)
            {
                return NotFound();
            }
            var entidade = await _context.Entidades.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }

            _context.Entidades.Remove(entidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntidadeExists(int id)
        {
            return (_context.Entidades?.Any(e => e.IdEntidade == id)).GetValueOrDefault();
        }
    }
}
