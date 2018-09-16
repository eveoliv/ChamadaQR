using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;

namespace ChamadaWS.Repositorio
{
    public class FrequenciaRepositorio : IFrequenciaRepositorio
    {
        private readonly WSDbContext _context;

        public FrequenciaRepositorio(WSDbContext context)
        {
            _context = context;
        }

        public void Add(Frequencia frequencia)
        {
            _context.Add(frequencia);
            _context.SaveChanges();
        }

        public Frequencia Find(long id)
        {            
            return _context.Frequencias.FirstOrDefault(p => p.FrequenciaID == id);
        }

        public IEnumerable<Frequencia> GetAll()
        {
            return _context.Frequencias.ToList();
        }

        public void Remove(long id)
        {
            var frequencia = _context.Frequencias.FirstOrDefault(p => p.FrequenciaID == id);
            _context.Frequencias.Remove(frequencia);
            _context.SaveChanges();
        }

        public void Update(Frequencia frequencia)
        {
            _context.Frequencias.Update(frequencia);
            _context.SaveChanges();
        }
    }
}
