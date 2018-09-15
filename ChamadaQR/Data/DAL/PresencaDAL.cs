using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class PresencaDAL
    {
        private IESContext _context;

        public PresencaDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Presenca> ObterPresencasClassificadasPorNome()
        {
            return _context.Presencas.Include(d => d.Calendario).Include(a => a.Aluno).OrderBy(i => i.Aluno.Nome);
        }
      
       public async Task<Presenca>ObterPresencaPorID(long id)
        {
            var presenca = await _context.Presencas.SingleOrDefaultAsync(p => p.PresencaID == id);
            _context.Calendarios.Where(p => presenca.DataID == p.DataID).Load(); ;
            return presenca;
        }

        public async Task<Presenca> GravarPresenca(Presenca presenca)
        {
            if (presenca.DataID == null)
            {
                _context.Presencas.Add(presenca);
            }
            else
            {
                _context.Update(presenca);
            }
            await _context.SaveChangesAsync();
            return presenca;
        }

        public async Task<Presenca> EliminarPresencaPorId(long id)
        {
            Presenca presenca = await ObterPresencaPorID(id);
            _context.Presencas.Remove(presenca);
            await _context.SaveChangesAsync();
            return presenca;
        }
    }
}
