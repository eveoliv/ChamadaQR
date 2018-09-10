using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadaWS.Models
{
    public class WSDbContext : DbContext
    {
        public WSDbContext(DbContextOptions<WSDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Presenca>().ToTable("Aluno");
        }
    }
}//https://www.youtube.com/watch?v=li_vY4vJbA4
