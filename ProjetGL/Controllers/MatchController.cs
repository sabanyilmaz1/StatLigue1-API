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
    public class MatchController : Controller
    {
        private readonly ProjetGLContext _context;

        public MatchController(ProjetGLContext context)
        {
            _context = context;
        }

        // GET: Match
        public async Task<IActionResult> Index()
        {
            var projetGLContext = _context.Match.Include(m => m.EquipeD).Include(m => m.EquipeE);
            return View(await projetGLContext.ToListAsync());
        }

        // GET: Match/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.EquipeD)
                .Include(m => m.EquipeE)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Match/Create
        public IActionResult Create()
        {
            ViewData["EquipeDId"] = new SelectList(_context.Equipe, "Id", "Id");
            ViewData["EquipeEId"] = new SelectList(_context.Equipe, "Id", "Id");
            return View();
        }

        // POST: Match/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipeDId,EquipeEId,ScoreD,ScoreE,DateMatch")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeDId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeDId);
            ViewData["EquipeEId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeEId);
            return View(match);
        }

        // GET: Match/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["EquipeDId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeDId);
            ViewData["EquipeEId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeEId);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipeDId,EquipeEId,ScoreD,ScoreE,DateMatch")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["EquipeDId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeDId);
            ViewData["EquipeEId"] = new SelectList(_context.Equipe, "Id", "Id", match.EquipeEId);
            return View(match);
        }

        // GET: Match/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.EquipeD)
                .Include(m => m.EquipeE)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
