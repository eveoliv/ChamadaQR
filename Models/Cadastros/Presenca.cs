using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Cadastros
{
    public class Presenca
    {
        [Key]
        public long? PresencaID { get; set; }       

        //fk
        public long? AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        //fk
        public long? CalendarioID { get; set; }
        public Calendario Calendario { get; set; }

    }
}
