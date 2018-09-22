using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Cadastros
{
    public class Professor
    {
        [Key]
        public int ProfessorID { get; set; }
        public long Matricula { get; set; }
        public string ProfessorNome { get; set; }
        public string Status { get; set; }

        //fk
        public long? ProjetoID { get; set; }
        public Projeto Projeto { get; set; }

    }
}
