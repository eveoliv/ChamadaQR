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
                new Projeto { ProjetoNome="ChamadaQR", Endereco="Vergueiro"},
                new Projeto { ProjetoNome="Agendamentos", Endereco="Santo Amaro"}
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
                new Aluno { Matricula = 2515201261, AlunoNome="Primeiro Aluno", Status ="A", ProjetoID = 1 },
                new Aluno { Matricula = 2515201262, AlunoNome="Segundo Aluno", Status ="A", ProjetoID = 1 },
                new Aluno { Matricula = 2515201263, AlunoNome="Terceiro Aluno", Status ="A", ProjetoID = 2 },
                new Aluno { Matricula = 2515201264, AlunoNome="Quarto Aluno", Status ="A", ProjetoID = 2 }
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
                new Calendario { DataNome = "08/09/2018" },
                new Calendario { DataNome = "14/09/2018" }
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
                new Frequencia { AlunoID = 1, DataID = 1, Presenca = "S" },
                new Frequencia { AlunoID = 2, DataID = 1, Presenca = "S" },
                new Frequencia { AlunoID = 3, DataID = 1, Presenca = "N", Justificativa = "Atestado Medico" },
                new Frequencia { AlunoID = 4, DataID = 1, Presenca = "S" }
            };

            foreach (Frequencia p in frequencias)
            {
                context.Frequencias.Add(p);
            }
            context.SaveChanges();
        }
    }
}
