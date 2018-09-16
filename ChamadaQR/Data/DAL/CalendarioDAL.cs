using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaQR.Data.DAL
{
    public class CalendarioDAL
    {
        private IESContext _context;

        public CalendarioDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Calendario> ObterCalendariosClassificadosPorNome()
        {
            return _context.Calendarios.OrderBy(c => c.DataNome);
        }

        public async Task<Calendario> ObterCalendarioPorId(long id)
        {
            return await _context.Calendarios.SingleOrDefaultAsync(c => c.DataID == id);
        }

        public async Task<Calendario> GravarCalendario(Calendario calendario)
        {
            if (calendario.DataID == null)
            {
                _context.Calendarios.Add(calendario);
            }
            else
            {
                _context.Calendarios.Update(calendario);
            }
            await _context.SaveChangesAsync();
            return calendario;
        }

        public async Task<Calendario> EliminarCalendarioPorId(long id)
        {
            Calendario calendario = await ObterCalendarioPorId(id);
            _context.Calendarios.Remove(calendario);
            await _context.SaveChangesAsync();
            return calendario;
        }
    }
}
