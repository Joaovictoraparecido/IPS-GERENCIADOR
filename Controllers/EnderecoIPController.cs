using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ips.Models;

namespace ips.Controllers
{
    public class EnderecoIPController : Controller
    {
        private readonly BancoDeDados1 _context;

        public EnderecoIPController(BancoDeDados1 context)
        {
            _context = context;
        }

        // GET: EnderecoIP
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnderecoIPs.ToListAsync());
        }

        // GET: EnderecoIP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoIP = await _context.EnderecoIPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoIP == null)
            {
                return NotFound();
            }

            return View(enderecoIP);
        }

        // GET: EnderecoIP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnderecoIP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IP,ConfiguracaoDoPC,Empresa,Setor,Bloco")] EnderecoIP enderecoIP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoIP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoIP);
        }

        // GET: EnderecoIP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoIP = await _context.EnderecoIPs.FindAsync(id);
            if (enderecoIP == null)
            {
                return NotFound();
            }
            return View(enderecoIP);
        }

        // POST: EnderecoIP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IP,ConfiguracaoDoPC,Empresa,Setor,Bloco")] EnderecoIP enderecoIP)
        {
            if (id != enderecoIP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoIP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoIPExists(enderecoIP.Id))
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
            return View(enderecoIP);
        }

        // GET: EnderecoIP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoIP = await _context.EnderecoIPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoIP == null)
            {
                return NotFound();
            }

            return View(enderecoIP);
        }

        // POST: EnderecoIP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enderecoIP = await _context.EnderecoIPs.FindAsync(id);
            _context.EnderecoIPs.Remove(enderecoIP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoIPExists(int id)
        {
            return _context.EnderecoIPs.Any(e => e.Id == id);
        }
    }
}
