using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Modelo.Cadastros
{
    public class Aluno
    {
        /*No relacionamento do Entity,conforme o layout abaixo o aluno é a CHAVE PRIMARIA,
         *e o projeto, a CHAVE ESTRANGEIRA. Deste modo o EF fara a criação das tabelas em 
         * banco e o relacionamento entre as mesmas
         */
         //pk
        [Key]
        public long? AlunoID { get; set; }
        public long Matricula { get; set; }
        public string AlunoNome { get; set; }
        public string Status { get; set; }

        //fk
        public long? ProjetoID { get; set; }
        public Projeto Projeto { get; set; }    

      
    }
}
