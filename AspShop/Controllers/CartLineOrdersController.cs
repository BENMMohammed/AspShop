using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspShop.Data;
using AspShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace AchatEnLigne.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class CartLineOrdersController : Controller
    {
        private readonly DataContext _context;

        public CartLineOrdersController(DataContext context)
        {
            _context = context;
        }

        // GET: CartLineOrder
        public async Task<IActionResult> Index()
        {
            var order = _context.Order;
            ViewBag.order = order;
            var product = _context.Products;
            ViewBag.Products = product;
            var cartItem = _context.CartItem;
            ViewBag.cartItem = cartItem;
            var DataContext = _context.CartLineOrder.Include(l => l.Order).Include(l => l.User);
            return View(await DataContext.ToListAsync());
        }

        // GET: LignePanierCommandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CartLineOrder == null)
            {
                return NotFound();
            }

            var CartLineOrder = await _context.CartLineOrder
                .Include(l => l.Order)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.CartLineOrderId == id);
            if (CartLineOrder == null)
            {
                return NotFound();
            }

            return View(CartLineOrder);
        }

        // GET: LignePanierCommandes/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: LignePanierCommandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LignepanierCommandeId,Qte,UserId,CommandeId")] CartLineOrder CartLineOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CartLineOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", CartLineOrder.OrderId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", CartLineOrder.UserId);
            return View(CartLineOrder);
        }

        // GET: LignePanierCommandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CartLineOrder == null)
            {
                return NotFound();
            }

            var cartLineOrder = await _context.CartLineOrder.FindAsync(id);
            if (cartLineOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", cartLineOrder.OrderId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", cartLineOrder.UserId);
            return View(cartLineOrder);
        }

        // POST: LignePanierCommandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartLineOrderId,Quantity,UserId,OrderId")] CartLineOrder cartLineOrder)
        {
            if (id != cartLineOrder.CartLineOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartLineOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartLineOrderExists(cartLineOrder.CartLineOrderId))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", cartLineOrder.OrderId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", cartLineOrder.UserId);
            return View(cartLineOrder);
        }

        // GET: LignePanierCommandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartLineOrder == null)
            {
                return NotFound();
            }

            var cartLineOrder = await _context.CartLineOrder
                .Include(l => l.Order)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.CartLineOrderId == id);
            if (cartLineOrder == null)
            {
                return NotFound();
            }

            return View(cartLineOrder);
        }

        // POST: LignePanierCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CartLineOrder == null)
            {
                return Problem("Entity set 'DataContext.CartLineOrder'  is null.");
            }
            var cartLineOrder = await _context.CartLineOrder.FindAsync(id);
            if (cartLineOrder != null)
            {
                _context.CartLineOrder.Remove(cartLineOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartLineOrderExists(int id)
        {
            return _context.CartLineOrder.Any(e => e.CartLineOrderId == id);
        }
    }
}