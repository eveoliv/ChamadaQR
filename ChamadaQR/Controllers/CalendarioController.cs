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

        //Get Calendario
        public async Task<IActionResult> Index()
        {
            return View(await calendarioDAL.ObterCalendariosClassificadosPorNome().ToListAsync());
        }
        
    }
}