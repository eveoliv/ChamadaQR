using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IPresencaRepositorio
    {
        void Add(Presenca presenca);
        IEnumerable<Presenca> GetAll();
        Presenca Find(long id);
        void Remove(long id);
        void Update(Presenca presenca);
    }
}
