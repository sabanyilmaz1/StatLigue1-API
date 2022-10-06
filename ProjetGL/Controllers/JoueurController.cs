using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetGL.Models;

namespace ProjetGL.Controllers
{
    public class JoueurController : Controller
    {
        private readonly ProjetGLContext _context;

        public JoueurController(ProjetGLContext context)
        {
            _context = context;
        }

        // GET: Joueur
        public async Task<IActionResult> Index()
        {
            var projetGLContext = _context.Joueur.Include(j => j.Equipe);
            return View(await projetGLContext.ToListAsync());
        }

        // GET: Joueur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur
                .Include(j => j.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueur/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id");
            return View();
        }

        // POST: Joueur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipeId,NomJoueur,PrenomJoueur,AgeJoueur,NationaliteJoueur,TailleJoueur,PosteJoueur,MatchJouee,CartonJaune,CartonRouge,ButJoueur,PasseDecisiveJoueur")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            return View(joueur);
        }

        // GET: Joueur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            return View(joueur);
        }

        // POST: Joueur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipeId,NomJoueur,PrenomJoueur,AgeJoueur,NationaliteJoueur,TailleJoueur,PosteJoueur,MatchJouee,CartonJaune,CartonRouge,ButJoueur,PasseDecisiveJoueur")] Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueur.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            return View(joueur);
        }

        // GET: Joueur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur
                .Include(j => j.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: Joueur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joueur = await _context.Joueur.FindAsync(id);
            _context.Joueur.Remove(joueur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoueurExists(int id)
        {
            return _context.Joueur.Any(e => e.Id == id);
        }
    }
}
