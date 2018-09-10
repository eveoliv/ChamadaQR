using Modelo.Cadastros;
using System.Linq;

namespace Persistencia.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Alunos.Any())
            {
                return;
            }

            var projetos = new Projeto[]
            {
                new Projeto { Nome="ChamdaQR", Endereco="Vergueiro"},
                new Projeto { Nome="Agendamentos", Endereco="Santo Amaro"}
            };

            foreach (Projeto i in projetos)
            {
                context.Projetos.Add(i);
            }
            context.SaveChanges();

            var alunos = new Aluno[]
            {
                new Aluno { Nome="Primeiro Aluno", ProjetoID=1 },
                new Aluno { Nome="Segundo Aluno", ProjetoID=2}
            };

            foreach (Aluno d in alunos)
            {
                context.Alunos.Add(d);
            }
            context.SaveChanges();
        }
    }
}
