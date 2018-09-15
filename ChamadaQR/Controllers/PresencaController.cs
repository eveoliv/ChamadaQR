using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChamadaQR.Controllers
{
    public class PresencaController : Controller
    {
        private readonly IESContext _context;
        private readonly PresencaDAL presencaDAL;

        public PresencaController(IESContext context)
        {
            _context = context;
            presencaDAL = new PresencaDAL(context);
        }

        //GET: Presensa
        public async Task<IActionResult> Index()
        {
            return View(await presencaDAL.ObterPresencasClassificadasPorNome().ToListAsync());
        }
    }
}