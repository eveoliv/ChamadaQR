using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface ICalendarioRepositorio
    {
        void Add(Calendario calendario);
        IEnumerable<Calendario> GetAll();
        Calendario Find(long id);
        void Remove(long id);
        void Update(Calendario calendario);
    }
}
