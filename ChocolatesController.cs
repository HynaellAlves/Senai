using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PBL.Models;

namespace PBL.Controllers
{
    public class ChocolatesController : Controller
    {
        private readonly PBLContext _context;

        public ChocolatesController(PBLContext context)
        {
            _context = context;
        }

        // GET: Chocolates
        public async Task<IActionResult> Index()
        {
            return View(await _context.chocolates.ToListAsync());
        }

        // GET: Chocolates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.chocolates
                .FirstOrDefaultAsync(m => m.Id_Chocolate == id);
            if (chocolate == null)
            {
                return NotFound();
            }

            return View(chocolate);
        }

        // GET: Chocolates/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Chocolates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Chocolate,Marca,Validade,Tipo,Cacao,Preco,Desconto")] chocolate chocolate)
        {
            if (ModelState.IsValid)
            {

                Calcular(chocolate);

                _context.Add(chocolate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chocolate);
        }

        public IActionResult Calcular([Bind("Id_Chocolate,Marca,Validade,Tipo,Cacao,Preco,Desconto")] chocolate chocolate)
        {
            var Valor = chocolate.Preco;
            try
            {
                if (chocolate.Tipo == "")
                {

                    chocolate.Tipo = "Tradicional";

                }

                if (chocolate.Desconto == 5)
                {

                    Valor = (chocolate.Preco - 5);
                    chocolate.Preco = Valor;
                }
                else

                if (chocolate.Desconto == 10)
                {

                    Valor = (chocolate.Preco - 10);
                    chocolate.Preco = Valor;

                }
                else

                if (chocolate.Desconto == 15)
                {

                    Valor = (chocolate.Preco - 15);
                    chocolate.Preco = Valor;

                }
                else
                {

                    chocolate.Desconto = 0;
                }
            }

            catch
            {
                NotFound();
            }
            _context.Add(chocolate);
            return View(chocolate);
        }

        // GET: Chocolates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.chocolates.FindAsync(id);
            if (chocolate == null)
            {
                return NotFound();
            }
            return View(chocolate);
        }

        // POST: Chocolates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Chocolate,Marca,Validade,Tipo,Cacao,Preco,Desconto")] chocolate chocolate)
        {
            if (id != chocolate.Id_Chocolate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    Calcular(chocolate);

                    _context.Update(chocolate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chocolateExists(chocolate.Id_Chocolate))
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
            return View(chocolate);
        }

        // GET: Chocolates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chocolate = await _context.chocolates
                .FirstOrDefaultAsync(m => m.Id_Chocolate == id);
            if (chocolate == null)
            {
                return NotFound();
            }

            return View(chocolate);
        }

        // POST: Chocolates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chocolate = await _context.chocolates.FindAsync(id);
            _context.chocolates.Remove(chocolate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool chocolateExists(int id)
        {
            return _context.chocolates.Any(e => e.Id_Chocolate == id);
        }

        // GET: Chocolates/Gourmet
         public async Task<IActionResult> Gourmet()
        {
            return View(await _context.chocolates.ToListAsync());
        }

    }
}
