using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamadaWS.Models
{
    public class Frequencia
    {   
        [Key]
        public long? FrequenciaID { get; set; }        
        public long? AlunoID { get; set; }
        public long? DataID { get; set; }
        public string Presenca { get; set; }

    }
}
