﻿using System;
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
    public class LicitacoesController : ControllerBase
    {
        private readonly BancoDadosCLContext _context;

        public LicitacoesController(BancoDadosCLContext context)
        {
            _context = context;
        }

        // GET: api/Licitacoes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Licitacao>>> GetLicitacoes()
        {
          if (_context.Licitacoes == null)
          {
              return NotFound();
          }
            return await _context.Licitacoes.ToListAsync();
        }

        // GET: api/Licitacoes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Licitacao>> GetLicitaco(int id)
        {
          if (_context.Licitacoes == null)
          {
              return NotFound();
          }
            var licitaco = await _context.Licitacoes.FindAsync(id);

            if (licitaco == null)
            {
                return NotFound();
            }

            return licitaco;
        }

        // PUT: api/Licitacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLicitaco(int id, Licitacao licitaco)
        {
            if (id != licitaco.IdLicitacao)
            {
                return BadRequest();
            }

            _context.Entry(licitaco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicitacoExists(id))
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

        // POST: api/Licitacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Licitacao>> PostLicitaco(Licitacao licitaco)
        {
          if (_context.Licitacoes == null)
          {
              return Problem("Entity set 'BancoDadosCLContext.Licitacoes'  is null.");
          }
            _context.Licitacoes.Add(licitaco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicitaco", new { id = licitaco.IdLicitacao }, licitaco);
        }

        // DELETE: api/Licitacoes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLicitaco(int id)
        {
            if (_context.Licitacoes == null)
            {
                return NotFound();
            }
            var licitaco = await _context.Licitacoes.FindAsync(id);
            if (licitaco == null)
            {
                return NotFound();
            }

            _context.Licitacoes.Remove(licitaco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicitacoExists(int id)
        {
            return (_context.Licitacoes?.Any(e => e.IdLicitacao == id)).GetValueOrDefault();
        }
    }
}
