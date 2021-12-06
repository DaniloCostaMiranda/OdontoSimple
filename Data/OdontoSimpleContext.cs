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
    public DbSet<TratamentoDente> TratamentoDente { get; set; }
    public DbSet<DenteProcedimento> DenteProcedimento { get; set; }
    //public DbSet<TratamentoDente> TratamentoDentes { get; set; }
    //public DbSet<DenteProcedimento> DenteProcedimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TratamentoDente>()
           .HasKey(t => t.Id);

        modelBuilder.Entity<TratamentoDente>()
            .HasOne(pt => pt.Tratamento)
            .WithMany(p => p.TratamentoDentes)
            .HasForeignKey(pt => pt.TratamentoId);


        modelBuilder.Entity<TratamentoDente>()
                .HasOne(pt => pt.Dente)
                .WithMany(p => p.TratamentoDentes)
                .HasForeignKey(pt => pt.DenteId);

        modelBuilder.Entity<DenteProcedimento>()
           .HasKey(t => t.Id);

        modelBuilder.Entity<DenteProcedimento>()
            .HasOne(pt => pt.TratamentoDente)
            .WithMany(p => p.DenteProcedimentos)
            .HasForeignKey(pt => pt.TratamentoDenteId);

        modelBuilder.Entity<DenteProcedimento>()
                .HasOne(pt => pt.Procediment)
                .WithMany(p => p.DenteProcedimentos)
                .HasForeignKey(pt => pt.ProcedimentId);

    }
   
      
        
}
