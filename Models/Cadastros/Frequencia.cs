using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Cadastros
{
    public class Frequencia
    {
        [Key]
        public long? FrequenciaID { get; set; }       

        //fk
        public long? AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        //fk
        public long? DataID { get; set; }
        public Calendario Calendario { get; set; }

        public string Presenca { get; set; }
        public string Justificativa { get; set; }
    }
}
