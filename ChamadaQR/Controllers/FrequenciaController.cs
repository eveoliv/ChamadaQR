using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace ChamadaQR.Controllers
{
    public class FrequenciaController : Controller
    {
        private readonly IESContext _context;
        private readonly FrequenciaDAL frequenciaDAL;
        private readonly AlunoDAL alunoDAL;
        private readonly CalendarioDAL calendarioDAL;

        public FrequenciaController(IESContext context)
        {
            _context = context;
            frequenciaDAL = new FrequenciaDAL(context);
            alunoDAL = new AlunoDAL(context);
            calendarioDAL = new CalendarioDAL(context);
        }

        //GET: Frequencia
        public async Task<IActionResult> Index()
        {
            return View(await frequenciaDAL.ObterFrequenciasClassificadasPorNome().ToListAsync());
        }

        private async Task<IActionResult> ObterVisaoFrequenciaPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var frequencia = await frequenciaDAL.ObterFrequenciaPorID((long)id);
            if (frequencia == null)
            {
                return NotFound();
            }
            return View(frequencia);
        }

        //public async Task<IActionResult> Detail(long? id)
        //{
        //    return await ObterVisaoFrequenciaPorId(id);
        //}

        //public async Task<IActionResult> Edit(long id)
        //{
        //    return await ObterVisaoFrequenciaPorId(id);
        //}

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequencia = await _context.Frequencias
                                           .Include(a => a.Aluno)
                                           .Include(c => c.Calendario)
                                           .SingleOrDefaultAsync(f => f.FrequenciaID == id);

            if (frequencia == null)
            {
                return NotFound();
            }

            return View(frequencia);
        }

        //GET: Frequencia
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }     
            var frequencia = await _context.Frequencias
                                           .Include(a => a.Aluno)
                                           .Include(c => c.Calendario)
                                           .SingleOrDefaultAsync(f => f.FrequenciaID == id);

            if (frequencia == null)
            {
                return NotFound();
            }
            ViewBag.Calendarios = new SelectList(_context.Calendarios.OrderBy(c => c.DataNome), "DataID","DataNome", frequencia.DataID);            
            return View(frequencia);
        }
    }
}