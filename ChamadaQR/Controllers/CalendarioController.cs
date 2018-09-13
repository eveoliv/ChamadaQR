using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly IESContext _context;
        private readonly CalendarioDAL calendarioDAL;

        public CalendarioController(IESContext context)
        {
            _context = context;
            calendarioDAL = new CalendarioDAL(context);
        }

        //Get Calendario/Index
        public async Task<IActionResult> Index()
        {
            return View(await calendarioDAL.ObterCalendariosClassificadosPorNome().ToListAsync());
        }

        private async Task<IActionResult> ObterVisaoCalendarioPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await calendarioDAL.ObterCalendarioPorId((long)id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View();
        }

        //Visoes
        public async Task<IActionResult> Detail(long? id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }

        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoCalendarioPorId(id);
        }

        // Acoes
        // GET: Calendario/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var calendario = await _context.Calendarios.SingleOrDefaultAsync(c => c.DataID == id);
            
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        //Get Calendario/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataNome")] Calendario calendario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await calendarioDAL.GravarCalendario(calendario);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(calendario);
        }
        
        //Calendario Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DataID,DataNome")] Calendario calendario)
        {
            if (id != calendario.DataID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await calendarioDAL.GravarCalendario(calendario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CalendarioExists(calendario.DataID))
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
            return View(calendario);
        }

        // POST: Calendario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var calendario = await calendarioDAL.EliminarCalendarioPorId((long)id);
            TempData["Message"] = "A Data " + calendario.DataNome.ToUpper() + " foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CalendarioExists(long? id)
        {
            return await calendarioDAL.ObterCalendarioPorId((long)id) != null;
        }
    }
}