using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webcodefirst.Models;

namespace webcodefirst.Controllers
{
    public class TblProductoesController : Controller
    {
        private readonly dbLSCContext _context;

        public TblProductoesController(dbLSCContext context)
        {
            _context = context;
        }

        // GET: TblProductoes
        public async Task<IActionResult> Index()
        {
            var dbLSCContext = _context.TblProductos.Include(t => t.TblColor);
            return View(await dbLSCContext.ToListAsync());
        }

        // GET: TblProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProductos
                .Include(t => t.TblColor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProducto == null)
            {
                return NotFound();
            }

            return View(tblProducto);
        }

        // GET: TblProductoes/Create
        public IActionResult Create()
        {
            ViewData["TblColorId"] = new SelectList(_context.TblColors, "Id", "CodigoColor");
            return View();
        }

        // POST: TblProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoProducto,Nombre,Descripcion,TblColorId,Existencia")] TblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TblColorId"] = new SelectList(_context.TblColors, "Id", "CodigoColor", tblProducto.TblColorId);
            return View(tblProducto);
        }

        // GET: TblProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProductos.FindAsync(id);
            if (tblProducto == null)
            {
                return NotFound();
            }
            ViewData["TblColorId"] = new SelectList(_context.TblColors, "Id", "CodigoColor", tblProducto.TblColorId);
            return View(tblProducto);
        }

        // POST: TblProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoProducto,Nombre,Descripcion,TblColorId,Existencia")] TblProducto tblProducto)
        {
            if (id != tblProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductoExists(tblProducto.Id))
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
            ViewData["TblColorId"] = new SelectList(_context.TblColors, "Id", "CodigoColor", tblProducto.TblColorId);
            return View(tblProducto);
        }

        // GET: TblProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProductos
                .Include(t => t.TblColor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProducto == null)
            {
                return NotFound();
            }

            return View(tblProducto);
        }

        // POST: TblProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProducto = await _context.TblProductos.FindAsync(id);
            _context.TblProductos.Remove(tblProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductoExists(int id)
        {
            return _context.TblProductos.Any(e => e.Id == id);
        }
    }
}
