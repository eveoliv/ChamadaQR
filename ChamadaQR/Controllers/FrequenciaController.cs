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
    public class FrequenciaController : Controller
    {
        private readonly IESContext _context;
        private readonly FrequenciaDAL frequenciaDAL;

        public FrequenciaController(IESContext context)
        {
            _context = context;
            frequenciaDAL = new FrequenciaDAL(context);
        }

        //GET: Frequencia
        public async Task<IActionResult> Index()
        {
            return View(await frequenciaDAL.ObterFrequenciasClassificadasPorNome().ToListAsync());
        }
    }
}