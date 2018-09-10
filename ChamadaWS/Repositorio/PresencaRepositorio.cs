using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;

namespace ChamadaWS.Repositorio
{
    public class PresencaRepositorio : IPresencaRepositorio
    {
        private readonly WSDbContext _context;

        public PresencaRepositorio(WSDbContext context)
        {
            _context = context;
        }

        public void Add(Presenca presenca)
        {
            _context.Add(presenca);
            _context.SaveChanges();
        }

        public Presenca Find(long id)
        {            
            return _context.Presencas.FirstOrDefault(p => p.PresencaID == id);
        }

        public IEnumerable<Presenca> GetAll()
        {
            return _context.Presencas.ToList();
        }

        public void Remove(long id)
        {
            var presenca = _context.Presencas.FirstOrDefault(p => p.PresencaID == id);
            _context.Presencas.Remove(presenca);
            _context.SaveChanges();
        }

        public void Update(Presenca presenca)
        {
            _context.Presencas.Update(presenca);
            _context.SaveChanges();
        }
    }
}
