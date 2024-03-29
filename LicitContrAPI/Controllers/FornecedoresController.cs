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
    public class FornecedoresController : ControllerBase
    {
        private readonly BancoDadosCLContext _context;

        public FornecedoresController(BancoDadosCLContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
          if (_context.Fornecedores == null)
          {
              return NotFound();
          }
            return await _context.Fornecedores.ToListAsync();
        }

        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Fornecedor>> GetFornecedore(int id)
        {
          if (_context.Fornecedores == null)
          {
              return NotFound();
          }
            var fornecedore = await _context.Fornecedores.FindAsync(id);

            if (fornecedore == null)
            {
                return NotFound();
            }

            return fornecedore;
        }

        // PUT: api/Fornecedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFornecedore(int id, Fornecedor fornecedore)
        {
            if (id != fornecedore.IdFornecedor)
            {
                return BadRequest();
            }

            _context.Entry(fornecedore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedoreExists(id))
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

        // POST: api/Fornecedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Fornecedor>> PostFornecedore(Fornecedor fornecedore)
        {
          if (_context.Fornecedores == null)
          {
              return Problem("Entity set 'BancoDadosCLContext.Fornecedores'  is null.");
          }
            _context.Fornecedores.Add(fornecedore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedore", new { id = fornecedore.IdFornecedor }, fornecedore);
        }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFornecedore(int id)
        {
            if (_context.Fornecedores == null)
            {
                return NotFound();
            }
            var fornecedore = await _context.Fornecedores.FindAsync(id);
            if (fornecedore == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedoreExists(int id)
        {
            return (_context.Fornecedores?.Any(e => e.IdFornecedor == id)).GetValueOrDefault();
        }
    }
}
