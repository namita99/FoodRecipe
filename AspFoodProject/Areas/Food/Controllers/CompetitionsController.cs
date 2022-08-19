using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspFoodProject.Data;
using AspFoodProject.Models;

namespace AspFoodProject.Areas.Food.Controllers
{
    [Area("Food")]
    public class CompetitionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetitionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Food/Competitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Food/Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // GET: Food/Competitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/Competitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,EventAddress,ImageUrl,IsEnabled,OrderDateTime,OrderDateTime1,hours1,Phase")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competition);
        }

        // GET: Food/Competitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Events.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }
            return View(competition);
        }

        // POST: Food/Competitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,EventAddress,ImageUrl,IsEnabled,OrderDateTime,OrderDateTime1,hours1,Phase")] Competition competition)
        {
            if (id != competition.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionExists(competition.EventId))
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
            return View(competition);
        }

        // GET: Food/Competitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // POST: Food/Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competition = await _context.Events.FindAsync(id);
            _context.Events.Remove(competition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
