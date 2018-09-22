using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Projeto
    {
        [Key]
        public long? ProjetoID { get; set; }
        public string ProjetoNome { get; set; }
        public string Endereco { get; set; }

        public virtual IEnumerable<Aluno> Alunos { get; set; }
        public virtual IEnumerable<Professor> Professores { get; set; }

    }
}
