using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetGL.Models;

namespace ProjetGL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchApiController : ControllerBase
    {
        private readonly ProjetGLContext _context;

        public MatchApiController(ProjetGLContext context)
        {
            _context = context;
        }

        // GET: api/MatchApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatch()
        {
            return await _context.Match.ToListAsync();
        }

        // GET: api/MatchApi/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _context.Match.FindAsync(id);

            
            
            if (match == null)
            {
                return NotFound();
            }

            return match;
            
        }
      
        [HttpGet("Matchs/{idEquipe}")]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchByTeam(int idEquipe){
             var query= from b in _context.Match select b;
            query=query.Where(b=>b.EquipeDId==idEquipe || b.EquipeEId==idEquipe);
            return await query.ToListAsync();
        }
        

        // PUT: api/MatchApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/MatchApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            _context.Match.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/MatchApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Match.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
