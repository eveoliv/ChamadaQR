using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Models
{
    public class Calendario
    {
        [Key]
        public long? DataID { get; set; }
        public string DataNome { get; set; }
    }
}
