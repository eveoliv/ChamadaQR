using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IFrequenciaRepositorio
    {
        void Add(Frequencia frequencia);
        IEnumerable<Frequencia> GetAll();
        Frequencia Find(long id);
        void Remove(long id);
        void Update(Frequencia frequencia);
    }
}
