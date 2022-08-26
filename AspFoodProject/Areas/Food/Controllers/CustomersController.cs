using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspFoodProject.Data;
using AspFoodProject.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AspFoodProject.Areas.Food.Controllers
{
    [Area("Food")]
    [Authorize(Roles = "AppUser, AppAdmin")]

    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomersController> _logger;


        public CustomersController(
                          ApplicationDbContext context,
                          ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;

        }

        // GET: Food/Customers
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("-------------- Retrieved all the Categories from the database");

            return View(await _context.Customers.ToListAsync());
        }

        // GET: Food/Customers
        public async Task<IActionResult> Index1()
        {
            _logger.LogInformation("-------------- Retrieved all the Categories from the database");

            return View(await _context.Customers.ToListAsync());
        }

        public async Task<IActionResult> ShowComment()
        {
            _logger.LogInformation("-------------- Retrieved all the Categories from the database");

            return View(await _context.Comments.ToListAsync());
        }

        public async Task<IActionResult> ShowCompetition()
        {
            _logger.LogInformation("-------------- Retrieved all the Categories from the database");

            return View(await _context.Events.ToListAsync());
        }


        // GET: Food/Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Food/Customers/Details/5
        public async Task<IActionResult> Details1(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Food/Customers/Details/5
        public async Task<IActionResult> DetailsCompetition(int? id)
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
        // GET: Food/Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerAddress,MobilePhone,EmailID")] Customer customerModel)
        {
            if (ModelState.IsValid)
            {
                // Sanitize the data before consumption
                customerModel.CustomerName = customerModel.CustomerName.Trim();

                // Check for Duplicate CategoryName
                bool isDuplicateFound
                    = _context.Customers.Any(c => c.CustomerName == customerModel.CustomerName);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("CustomerName", "Duplicate! Another customer with same name exists");
                }
                else
                {
                    // Save the changes 
                    _context.Add(customerModel);
                    await _context.SaveChangesAsync();              // update the database
                   // return RedirectToAction(nameof(Index));
                }
            }
            return View("Index1",customerModel);
        }

        [Authorize(Roles = "AppAdmin")]

        // GET: Food/Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Food/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,CustomerAddress,MobilePhone,EmailID")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        [Authorize(Roles = " AppAdmin")]

        // GET: Food/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Food/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
