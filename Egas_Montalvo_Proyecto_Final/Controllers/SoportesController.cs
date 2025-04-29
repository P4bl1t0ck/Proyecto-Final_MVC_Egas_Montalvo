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
    public class SoportesController : Controller
    {
        private readonly Servidor _context;

        public SoportesController(Servidor context)
        {
            _context = context;
        }

        // GET: Soportes
        public async Task<IActionResult> Index()
        {
            var servidor = _context.Soporte.Include(s => s.Usuario);
            return View(await servidor.ToListAsync());
        }

        // GET: Soportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soporte = await _context.Soporte
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soporte == null)
            {
                return NotFound();
            }

            return View(soporte);
        }

        // GET: Soportes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Soportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,TipoSolicitud,Descripcion,Estado,Fecha")] Soporte soporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", soporte.UsuarioId);
            return View(soporte);
        }

        // GET: Soportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soporte = await _context.Soporte.FindAsync(id);
            if (soporte == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", soporte.UsuarioId);
            return View(soporte);
        }

        // POST: Soportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,TipoSolicitud,Descripcion,Estado,Fecha")] Soporte soporte)
        {
            if (id != soporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoporteExists(soporte.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", soporte.UsuarioId);
            return View(soporte);
        }

        // GET: Soportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soporte = await _context.Soporte
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soporte == null)
            {
                return NotFound();
            }

            return View(soporte);
        }

        // POST: Soportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soporte = await _context.Soporte.FindAsync(id);
            if (soporte != null)
            {
                _context.Soporte.Remove(soporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoporteExists(int id)
        {
            return _context.Soporte.Any(e => e.Id == id);
        }
    }
}
