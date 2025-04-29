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
    public class ResenasController : Controller
    {
        private readonly Servidor _context;

        public ResenasController(Servidor context)
        {
            _context = context;
        }

        // GET: Resenas
        public async Task<IActionResult> Index()
        {
            var servidor = _context.Resena.Include(r => r.Producto).Include(r => r.Usuario);
            return View(await servidor.ToListAsync());
        }

        // GET: Resenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // GET: Resenas/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Resenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,ProductoId,Calificacion,Comentario,Fecha")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", resena.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", resena.UsuarioId);
            return View(resena);
        }

        // GET: Resenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena.FindAsync(id);
            if (resena == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", resena.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", resena.UsuarioId);
            return View(resena);
        }

        // POST: Resenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,ProductoId,Calificacion,Comentario,Fecha")] Resena resena)
        {
            if (id != resena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResenaExists(resena.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", resena.ProductoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", resena.UsuarioId);
            return View(resena);
        }

        // GET: Resenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena
                .Include(r => r.Producto)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // POST: Resenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resena = await _context.Resena.FindAsync(id);
            if (resena != null)
            {
                _context.Resena.Remove(resena);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResenaExists(int id)
        {
            return _context.Resena.Any(e => e.Id == id);
        }
    }
}
