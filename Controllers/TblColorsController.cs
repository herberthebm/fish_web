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
    public class TblColorsController : Controller
    {
        private readonly dbLSCContext _context;

        public TblColorsController(dbLSCContext context)
        {
            _context = context;
        }

        // GET: TblColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblColors.ToListAsync());
        }

        // GET: TblColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblColor = await _context.TblColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblColor == null)
            {
                return NotFound();
            }

            return View(tblColor);
        }

        // GET: TblColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoColor,CodigoHex,NombreColor,Foto,GrupoOrdenamiento")] TblColor tblColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblColor);
        }

        // GET: TblColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblColor = await _context.TblColors.FindAsync(id);
            if (tblColor == null)
            {
                return NotFound();
            }
            return View(tblColor);
        }

        // POST: TblColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoColor,CodigoHex,NombreColor,Foto,GrupoOrdenamiento")] TblColor tblColor)
        {
            if (id != tblColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblColorExists(tblColor.Id))
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
            return View(tblColor);
        }

        // GET: TblColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblColor = await _context.TblColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblColor == null)
            {
                return NotFound();
            }

            return View(tblColor);
        }

        // POST: TblColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblColor = await _context.TblColors.FindAsync(id);
            _context.TblColors.Remove(tblColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblColorExists(int id)
        {
            return _context.TblColors.Any(e => e.Id == id);
        }
    }
}
