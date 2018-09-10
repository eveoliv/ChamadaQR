using ChamadaWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Repositorio
{
    public interface IAlunoRepositorio
    {
        void Add(Aluno aluno);
        IEnumerable<Aluno> GetAll();
        Aluno Find(long id);
        void Remove(long id);
        void Update(Aluno aluno);
    }
}
