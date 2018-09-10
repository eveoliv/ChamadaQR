using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Persistencia.Data.DAL
{
    public class AlunoDAL
    {
        private IESContext _context;

        public AlunoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Aluno> ObterAlunosClassificadosPorNome()
        {
            return _context.Alunos.Include(i => i.Projeto).OrderBy(b => b.Nome);
        }

        public async Task<Aluno> ObterAlunoPorId(long id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(m => m.AlunoID == id);
            _context.Projetos.Where(i => aluno.ProjetoID == i.ProjetoID).Load(); ;
            return aluno;
        }

        public async Task<Aluno> GravarAluno(Aluno aluno)
        {
            if (aluno.AlunoID == null)
            {
                _context.Alunos.Add(aluno);
            }
            else
            {
                _context.Update(aluno);
            }
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> EliminarAlunoPorId(long id)
        {
            Aluno aluno = await ObterAlunoPorId(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
        
    }
}
