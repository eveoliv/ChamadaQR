using ChamadaQR.Data;
using ChamadaQR.Data.DAL;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IESContext _context;
        private readonly AlunoDAL alunoDAL;
        private readonly ProjetoDAL projetoDAL;

        public AlunoController(IESContext context)
        {
            this._context = context;
            projetoDAL = new ProjetoDAL(context);
            alunoDAL = new AlunoDAL(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await alunoDAL.ObterAlunosClassificadosPorNome().ToListAsync());
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            var Projetos = projetoDAL.ObterProjetosClassificadosPorNome().ToList();
            Projetos.Insert(0, new Projeto() { ProjetoID = 0, ProjetoNome = "Selecione a instituição" });
            ViewBag.Projetos = Projetos;
            return View();
        }

        // POST: Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjetoNome, ProjetoID")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await alunoDAL.GravarAluno(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.SingleOrDefaultAsync(m => m.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewBag.Projetos = new SelectList(_context.Projetos.OrderBy(b => b.ProjetoNome), "ProjetoID", "ProjetoNome", aluno.ProjetoID);

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("AlunoID,AlunoNome, ProjetoID")] Aluno aluno)
        {
            if (id != aluno.AlunoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoID))
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
            ViewBag.Projetos = new SelectList(_context.Projetos.OrderBy(b => b.ProjetoNome), "ProjetoID", "ProjetoNome", aluno.ProjetoID);
            return View(aluno);
        }

        private bool AlunoExists(long? id)
        {
            return _context.Alunos.Any(e => e.AlunoID == id);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Projetos.Where(i => aluno.ProjetoID == i.ProjetoID).Load(); ;
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Projeto/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Projetos.Where(i => aluno.ProjetoID == i.ProjetoID).Load(); ;
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Alunos.Remove(aluno);
            TempData["Message"] = "Aluno " + aluno.AlunoNome.ToUpper() + " foi removido";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}