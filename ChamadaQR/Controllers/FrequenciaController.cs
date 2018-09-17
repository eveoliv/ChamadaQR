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

        public async Task<IActionResult> Detail(long? id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoFrequenciaPorId(id);
        }

        // GET: Frequencia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var frequencia = await _context.Frequencias.Include(d => d.Alunos).SingleOrDefaultAsync(m => m.ProjetoID == id);
            var frequencia = await _context.Frequencias.Where(f => f.FrequenciaID == id)
                                                       .Include(a => a.Aluno)
                                                       .Include(d => d.Calendario).ToListAsync();
            if (frequencia == null)
            {
                return NotFound();
            }

            return View(frequencia);
        }
    }
}