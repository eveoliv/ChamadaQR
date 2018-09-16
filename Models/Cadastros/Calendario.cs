using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.Cadastros
{
    public class Calendario
    {
        [Key]
        public long? CalendrioID { get; set; }
        public string CalendarioNome { get; set; }

        public virtual IEnumerable<Frequencia> Frequencias { get; set; }
    }
}
