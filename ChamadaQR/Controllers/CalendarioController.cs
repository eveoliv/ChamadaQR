using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var calendario = await _context.Calendarios.Where(c => c.DataID == id).ToListAsync();
            
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
    }
}