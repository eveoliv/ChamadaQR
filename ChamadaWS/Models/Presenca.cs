using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamadaWS.Models
{
    public class Presenca
    {   
        [Key]
        public long? PresencaID { get; set; }        
        public long? AlunoID { get; set; }
        public long? CalendarioID { get; set; }
    }
}
