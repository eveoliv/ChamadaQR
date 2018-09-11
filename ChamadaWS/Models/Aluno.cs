using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChamadaWS.Models
{
    public class Aluno
    {
        [Key]
        public long? AlunoID { get; set; }
        public long Matricula { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }



    }
}
