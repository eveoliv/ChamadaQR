using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class FrequenciaDAL
    {
        private IESContext _context;

        public FrequenciaDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Frequencia> ObterFrequenciasClassificadasPorNome()
        {
            return _context.Frequencias.Include(d => d.Calendario).Include(a => a.Aluno).OrderBy(i => i.Aluno.Nome);
        }
      
       public async Task<Frequencia>ObterFrequenciaPorID(long id)
        {
            var frequencia = await _context.Frequencias.SingleOrDefaultAsync(p => p.FrequenciaID == id);
            _context.Calendarios.Where(p => frequencia.DataID == p.DataID).Load(); ;
            return frequencia;
        }

        public async Task<Frequencia> GravarFrequencia(Frequencia frequencia)
        {
            if (frequencia.DataID == null)
            {
                _context.Frequencias.Add(frequencia);
            }
            else
            {
                _context.Update(frequencia);
            }
            await _context.SaveChangesAsync();
            return frequencia;
        }

        public async Task<Frequencia> EliminarFrequenciaPorId(long id)
        {
            Frequencia frequencia = await ObterFrequenciaPorID(id);
            _context.Frequencias.Remove(frequencia);
            await _context.SaveChangesAsync();
            return frequencia;
        }
    }
}
