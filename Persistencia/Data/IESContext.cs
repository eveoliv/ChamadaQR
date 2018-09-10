using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class IESContext : DbContext
    {

        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Aluno>().ToTable("Aluno");
        //    modelBuilder.Entity<Projeto>().ToTable("Projeto");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IESUtfpr;Trusted_Connection=True;MultipleActiveResultSets= true");
        //}
    }
}
