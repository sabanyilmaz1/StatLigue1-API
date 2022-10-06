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
    public class JoueurApiController : ControllerBase
    {
        private readonly ProjetGLContext _context;

        public JoueurApiController(ProjetGLContext context)
        {
            _context = context;
        }

        // GET: api/JoueurApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueurs(string name)
        {
            if (name is not null) {
                var query= from b in _context.Joueur select b;
                query=query.Where(b=>b.NomJoueur.Contains(name));
                return await query.ToListAsync();
            }
            else
            {
                return await _context.Joueur.ToListAsync();
            }

            
        }

       

        // GET: api/JoueurApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joueur>> GetJoueur(int id)
        {
            var joueur = await _context.Joueur.FindAsync(id);

            if (joueur == null)
            {
                return NotFound();
            }

            Console.WriteLine("Get by Id");
            return joueur;
        }

        [HttpGet("EquipeId/{idEquipe}")]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueurbyTeam(int idEquipe)
        {
            var query= from b in _context.Joueur select b;
                query=query.Where(b=>b.EquipeId==idEquipe);
                return await query.ToListAsync();
        }


        // PUT: api/JoueurApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueur(int id, Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return BadRequest();
            }

            _context.Entry(joueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurExists(id))
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

        // POST: api/JoueurApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joueur>> PostJoueur(Joueur joueur)
        {
            _context.Joueur.Add(joueur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoueur", new { id = joueur.Id }, joueur);
        }

        // DELETE: api/JoueurApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueur(int id)
        {
            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }

            _context.Joueur.Remove(joueur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurExists(int id)
        {
            return _context.Joueur.Any(e => e.Id == id);
        }
    }
}
