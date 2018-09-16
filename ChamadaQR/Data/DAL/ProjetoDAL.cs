using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class ProjetoDAL
    {
        private IESContext _context;

        public ProjetoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Projeto> ObterProjetosClassificadosPorNome()
        {
            return _context.Projetos.OrderBy(b => b.ProjetoNome);
        }

        public async Task<Projeto> ObterProjetoPorId(long id)
        {
            return await _context.Projetos.Include(d => d.Alunos)
                .SingleOrDefaultAsync(m => m.ProjetoID == id);
        }

        public async Task<Projeto> GravarProjeto(Projeto projeto)
        {
            if (projeto.ProjetoID == null)
            {
                _context.Projetos.Add(projeto);
            }
            else
            {
                _context.Projetos.Update(projeto);
            }
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<Projeto> EliminaProjetoPorId(long id)
        {
            Projeto projeto = await ObterProjetoPorId(id);
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }
    }
}
