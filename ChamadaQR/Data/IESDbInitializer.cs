using Modelo.Cadastros;
using System.Linq;

namespace ChamadaQR.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Projetos
            if (context.Projetos.Any())
            {
                return;
            }

            var projetos = new Projeto[]
            {
                new Projeto { Nome="ChamadaQR", Endereco="Vergueiro"},
                new Projeto { Nome="Agendamentos", Endereco="Santo Amaro"}
            };

            foreach (Projeto i in projetos)
            {
                context.Projetos.Add(i);
            }
            context.SaveChanges();

            //Presenca
            if (context.Presencas.Any())
            {
                return;
            }

            var presencas = new Presenca[]
            {
                new Presenca { Data = "18/08/2018" }                
            };

            foreach (Presenca p in presencas)
            {
                context.Presencas.Add(p);
            }
            context.SaveChanges();

            //Alunos
            if (context.Alunos.Any())
            {
                return;
            }

            var alunos = new Aluno[]
            {
                new Aluno { Nome="Primeiro Aluno", ProjetoID=1 },
                new Aluno { Nome="Segundo Aluno", ProjetoID=2,},
                new Aluno { Nome="Terceiro Aluno", ProjetoID=2}
            };
        
            foreach (Aluno d in alunos)
            {
                context.Alunos.Add(d);
            }
            context.SaveChanges();

        }
    }
}
