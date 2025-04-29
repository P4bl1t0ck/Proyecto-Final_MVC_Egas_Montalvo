using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Egas_Montalvo_Proyecto_Final.Models;

namespace Egas_Montalvo_Proyecto_Final.Controllers
{
    public class TrasaccionProductoesController : Controller
    {
        private readonly Servidor _context;

        public TrasaccionProductoesController(Servidor context)
        {
            _context = context;
        }

        // GET: TrasaccionProductoes
        public async Task<IActionResult> Index()
        {
            var servidor = _context.TrasaccionProducto.Include(t => t.Producto).Include(t => t.Transaccion);
            return View(await servidor.ToListAsync());
        }

        // GET: TrasaccionProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trasaccionProducto = await _context.TrasaccionProducto
                .Include(t => t.Producto)
                .Include(t => t.Transaccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trasaccionProducto == null)
            {
                return NotFound();
            }

            return View(trasaccionProducto);
        }

        // GET: TrasaccionProductoes/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id");
            ViewData["TransaccionId"] = new SelectList(_context.Transaccion, "Id", "Id");
            return View();
        }

        // POST: TrasaccionProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransaccionId,ProductoId")] TrasaccionProducto trasaccionProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trasaccionProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", trasaccionProducto.ProductoId);
            ViewData["TransaccionId"] = new SelectList(_context.Transaccion, "Id", "Id", trasaccionProducto.TransaccionId);
            return View(trasaccionProducto);
        }

        // GET: TrasaccionProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trasaccionProducto = await _context.TrasaccionProducto.FindAsync(id);
            if (trasaccionProducto == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", trasaccionProducto.ProductoId);
            ViewData["TransaccionId"] = new SelectList(_context.Transaccion, "Id", "Id", trasaccionProducto.TransaccionId);
            return View(trasaccionProducto);
        }

        // POST: TrasaccionProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransaccionId,ProductoId")] TrasaccionProducto trasaccionProducto)
        {
            if (id != trasaccionProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trasaccionProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrasaccionProductoExists(trasaccionProducto.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", trasaccionProducto.ProductoId);
            ViewData["TransaccionId"] = new SelectList(_context.Transaccion, "Id", "Id", trasaccionProducto.TransaccionId);
            return View(trasaccionProducto);
        }

        // GET: TrasaccionProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trasaccionProducto = await _context.TrasaccionProducto
                .Include(t => t.Producto)
                .Include(t => t.Transaccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trasaccionProducto == null)
            {
                return NotFound();
            }

            return View(trasaccionProducto);
        }

        // POST: TrasaccionProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trasaccionProducto = await _context.TrasaccionProducto.FindAsync(id);
            if (trasaccionProducto != null)
            {
                _context.TrasaccionProducto.Remove(trasaccionProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrasaccionProductoExists(int id)
        {
            return _context.TrasaccionProducto.Any(e => e.Id == id);
        }
    }
}
