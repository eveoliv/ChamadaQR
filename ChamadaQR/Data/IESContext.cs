using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace ChamadaQR.Data
{
    public class IESContext : DbContext
    {
        //Corresponde a classe AlunoDBContext do ChamdaSW
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");
            modelBuilder.Entity<Presenca>().ToTable("Presenca");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESUtfpr;Trusted_Connection=True;MultipleActiveResultSets= true");
        }
    }
}
