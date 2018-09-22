using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class ProfessorDAL
    {
        private IESContext _context;

        public ProfessorDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Professor> ObterProfessoresClassificadosPorNome()
        {
            return _context.Professores.Include(i => i.Projeto).OrderBy(b => b.ProfessorNome);
        }

        public async Task<Professor> ObterProfessorPorId(long id)
        {
            var professor = await _context.Professores.SingleOrDefaultAsync(p => p.ProfessorID == id);
            _context.Projetos.Where(i => professor.ProjetoID == i.ProjetoID).Load(); ;
            return professor;
        }

    }
}
