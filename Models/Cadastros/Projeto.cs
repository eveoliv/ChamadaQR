using System.Collections.Generic;

namespace Modelo.Cadastros
{
    public class Projeto
    {
        public long? ProjetoID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public virtual IEnumerable<Aluno> Alunos { get; set; }

        
    }
}
