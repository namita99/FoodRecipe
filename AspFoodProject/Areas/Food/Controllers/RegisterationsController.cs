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
    public class RegisterationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Food/Registerations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Registeration.Include(r => r.Competition).Include(r => r.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Food/Registerations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = await _context.Registeration
                .Include(r => r.Competition)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (registeration == null)
            {
                return NotFound();
            }

            return View(registeration);
        }

        // GET: Food/Registerations/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Food/Registerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterId,RegisterAddress,RegisterNo,RegisterEmailID,IsEnabled,OrderDateTime,EventId,CustomerId")] Registeration registeration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registeration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", registeration.EventId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", registeration.CustomerId);
            return View(registeration);
        }

        // GET: Food/Registerations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = await _context.Registeration.FindAsync(id);
            if (registeration == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", registeration.EventId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", registeration.CustomerId);
            return View(registeration);
        }

        // POST: Food/Registerations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterId,RegisterAddress,RegisterNo,RegisterEmailID,IsEnabled,OrderDateTime,EventId,CustomerId")] Registeration registeration)
        {
            if (id != registeration.RegisterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registeration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterationExists(registeration.RegisterId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", registeration.EventId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", registeration.CustomerId);
            return View(registeration);
        }

        // GET: Food/Registerations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeration = await _context.Registeration
                .Include(r => r.Competition)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (registeration == null)
            {
                return NotFound();
            }

            return View(registeration);
        }

        // POST: Food/Registerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registeration = await _context.Registeration.FindAsync(id);
            _context.Registeration.Remove(registeration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterationExists(int id)
        {
            return _context.Registeration.Any(e => e.RegisterId == id);
        }
    }
}
