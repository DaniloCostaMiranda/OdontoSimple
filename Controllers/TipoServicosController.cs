using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;

namespace OdontoSimple.Controllers
{
    public class TipoServicosController : Controller
    {
        private readonly OdontoSimpleContext _context;

        public TipoServicosController(OdontoSimpleContext context)
        {
            _context = context;
        }

        // GET: TipoServicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoServico.ToListAsync());
        }

        // GET: TipoServicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoServico == null)
            {
                return NotFound();
            }

            return View(tipoServico);
        }

        // GET: TipoServicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoServicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoServico);
        }

        // GET: TipoServicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServico.FindAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            return View(tipoServico);
        }

        // POST: TipoServicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoServico tipoServico)
        {
            if (id != tipoServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoServicoExists(tipoServico.Id))
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
            return View(tipoServico);
        }

        // GET: TipoServicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoServico == null)
            {
                return NotFound();
            }

            return View(tipoServico);
        }

        // POST: TipoServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoServico = await _context.TipoServico.FindAsync(id);
            _context.TipoServico.Remove(tipoServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoServicoExists(int id)
        {
            return _context.TipoServico.Any(e => e.Id == id);
        }
    }
}
