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
    
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly ProfessorDAL professorDAL;
        private readonly ProjetoDAL projetoDAL;

        public ProfessorController(IESContext context)
        {
            this._context = context;
            projetoDAL = new ProjetoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await professorDAL.ObterProfessoresClassificadosPorNome().ToListAsync());
        }
    }
}