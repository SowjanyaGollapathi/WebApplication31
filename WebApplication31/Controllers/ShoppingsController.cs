using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication31.Data;
using WebApplication31.Models;

namespace WebApplication31.Controllers
{
    public class ShoppingsController : Controller
    {
        private readonly WebApplication31Context _context;

        public ShoppingsController(WebApplication31Context context)
        {
            _context = context;
        }

        // GET: Shoppings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shopping.ToListAsync());
        }

        // GET: Shoppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // GET: Shoppings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoppings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ProductPrice,ProductQuality,ProductColour")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping.FindAsync(id);
            if (shopping == null)
            {
                return NotFound();
            }
            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductPrice,ProductQuality,ProductColour")] Shopping shopping)
        {
            if (id != shopping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExists(shopping.Id))
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
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopping = await _context.Shopping.FindAsync(id);
            _context.Shopping.Remove(shopping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingExists(int id)
        {
            return _context.Shopping.Any(e => e.Id == id);
        }
    }
}
