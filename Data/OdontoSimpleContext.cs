using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdontoSimple.Models;

    public class OdontoSimpleContext : DbContext
    {
        public OdontoSimpleContext (DbContextOptions<OdontoSimpleContext> options)
            : base(options)
        {
        }

        
        public DbSet<Dente> Dente { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Procediment> Procediment { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tratamento> Tratamento { get; set; }
        public DbSet<TipoServico> TipoServico { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
}
