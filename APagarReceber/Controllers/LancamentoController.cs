using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APagarReceber.Data;
using APagarReceber.Models;

namespace APagarReceber.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly APRContext _context;

        public LancamentoController(APRContext context)
        {
            _context = context;
        }

        // GET: Lancamento
        public async Task<IActionResult> Index()
        {
              //return View(await _context.Lancamento.ToListAsync());
              return View(await _context.Lancamento.Include(l => l.Conta).ToListAsync());
        }

        // GET: Lancamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lancamento == null)
            {
                return NotFound();
            }


            var lancamento = await LeUmLancamento(id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // GET: Lancamento/Create
        public IActionResult Create()
        {
            List<Conta> contas = (from c in _context.Conta select c).ToList();
            ViewBag.Contas = contas;

            return View();
        }

        // POST: Lancamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContaId,Nome,Valor,Data,Observacao,Estado")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lancamento);
        }

        // GET: Lancamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lancamento == null)
            {
                return NotFound();
            }

            Lancamento? lancamento = await LeUmLancamento(id);

            if (lancamento == null)
            {
                return NotFound();
            }

            ViewBag.Contas = (from c in _context.Conta select c).ToList();

            return View(lancamento);
        }

        // POST: Lancamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContaId,Nome,Valor,Data,Observacao,Estado")] Lancamento lancamento)
        {
            if (id != lancamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lancamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancamentoExists(lancamento.Id))
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
            return View(lancamento);
        }

        // GET: Lancamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lancamento == null)
            {
                return NotFound();
            }

            Lancamento? lancamento = await LeUmLancamento(id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // POST: Lancamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lancamento == null)
            {
                return Problem("Entity set 'APRContext.Lancamento'  is null.");
            }
            var lancamento = await _context.Lancamento.FindAsync(id);
            if (lancamento != null)
            {
                _context.Lancamento.Remove(lancamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancamentoExists(int id)
        {
          return _context.Lancamento.Any(e => e.Id == id);
        }

        private async Task<Lancamento>? LeUmLancamento (int? id)
        {
            var lancamento = await _context.Lancamento.FindAsync(id);

            if (lancamento != null)
            {
                lancamento.Conta = await _context.Conta.Where(c => c.Id == lancamento.ContaId).FirstOrDefaultAsync();
            }

            return lancamento;
        }
    }
}
