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
    public class EquipeController : Controller
    {
        private readonly ProjetGLContext _context;

        public EquipeController(ProjetGLContext context)
        {
            _context = context;
        }

        // GET: Equipe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipe.ToListAsync());
        }

        // GET: Equipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var equipe = await _context.Equipe
                .Include(s => s.LesJoueurs)                
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);


            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // GET: Equipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomEquipe,AcronymeClub,NomEntraineur,NombrePoints,NombreVictoire,NombreDefaite,NombreNul,DifferencedeBut,ClassementEquipe")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }

        // GET: Equipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return View(equipe);
        }

        // POST: Equipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomEquipe,AcronymeClub,NomEntraineur,NombrePoints,NombreVictoire,NombreDefaite,NombreNul,DifferencedeBut,ClassementEquipe")] Equipe equipe)
        {
            if (id != equipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.Id))
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
            return View(equipe);
        }

        // GET: Equipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            _context.Equipe.Remove(equipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipe.Any(e => e.Id == id);
        }
    }
}
