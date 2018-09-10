using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChamadaQR.Data;
using Modelo.Cadastros;
using ChamadaQR.Data.DAL;

namespace ChamadaQR.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IESContext _context;
        private readonly ProjetoDAL projetoDAL;

        public ProjetoController(IESContext context)
        {
            _context = context;
            projetoDAL = new ProjetoDAL(context);
        }

        // GET: Projeto
        public async Task<IActionResult> Index()
        {
            return View(await projetoDAL.ObterProjetosClassificadosPorNome().ToListAsync());
        }       

       private async Task<IActionResult> ObterVisaoProjetoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projeto = await projetoDAL.ObterProjetoPorId((long)id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        public async Task<IActionResult> Detail(long? id)
        {
            return await ObterVisaoProjetoPorId(id);
        }

        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoProjetoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoProjetoPorId(id);
        }
        
        // GET: Projeto/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.Include(d => d.Alunos).SingleOrDefaultAsync(m => m.ProjetoID == id);
            //var projeto = await _context.Projetos.Where(i => i.ProjetoID == id).Include(d => d.Alunos).ToListAsync();
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projeto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco")] Projeto projeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await projetoDAL.GravarProjeto(projeto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(projeto);
        }
      

        // POST: Projeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProjetoID,Nome,Endereco")] Projeto projeto)
        {
            if (id != projeto.ProjetoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await projetoDAL.GravarProjeto(projeto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ProjetoExists(projeto.ProjetoID))
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
            return View(projeto);
        }      

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var projeto = await projetoDAL.EliminaProjetoPorId((long)id);
            TempData["Message"] = "Projeto " + projeto.Nome.ToUpper() + " foi removida";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjetoExists(long? id)
        {
            return await projetoDAL.ObterProjetoPorId((long)id) != null;
        }
    }
}
