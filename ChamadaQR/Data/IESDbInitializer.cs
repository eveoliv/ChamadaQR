using Modelo.Cadastros;
using System.Linq;

namespace ChamadaQR.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
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

            foreach (Projeto p in projetos)
            {
                context.Projetos.Add(p);
            }
            context.SaveChanges();            

            //Alunos
            if (context.Alunos.Any())
            {
                return;
            }

            var alunos = new Aluno[]
            {
                new Aluno { Matricula = 2515201261, Nome="Primeiro Aluno", Status ="A", ProjetoID = 1 },
                new Aluno { Matricula = 2515201262, Nome="Segundo Aluno", Status ="A", ProjetoID = 1 },
                new Aluno { Matricula = 2515201263, Nome="Terceiro Aluno", Status ="A", ProjetoID = 2 },
                new Aluno { Matricula = 2515201264, Nome="Quarto Aluno", Status ="A", ProjetoID = 2 }
            };
        
            foreach (Aluno a in alunos)
            {
                context.Alunos.Add(a);
            }
            context.SaveChanges();

            //Calendario
            if (context.Calendarios.Any())
            {
                return;
            }

            var calendario = new Calendario[]
            {
                new Calendario { CalendarioNome = "08/09/2018" },
                new Calendario { CalendarioNome = "14/09/2018" }
            };

            foreach (Calendario c in calendario)
            {
                context.Calendarios.Add(c);
            }
            context.SaveChanges();

            //Frequencia
            if (context.Frequencias.Any())
            {
                return;
            }

            var frequencias = new Frequencia[]
            {
                new Frequencia { AlunoID = 1, CalendarioID = 1, Presenca = "SIM" },
                new Frequencia { AlunoID = 2, CalendarioID = 1, Presenca = "SIM" },
                new Frequencia { AlunoID = 3, CalendarioID = 1, Presenca = "NAO" },
                new Frequencia { AlunoID = 4, CalendarioID = 1, Presenca = "SIM" }
            };

            foreach (Frequencia p in frequencias)
            {
                context.Frequencias.Add(p);
            }
            context.SaveChanges();
        }
    }
}
