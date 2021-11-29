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
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<TratamentoDente>()
            .HasOne(b => b.Tratamento)
            .WithMany(ba => ba.TratamentoDentes)
            .HasForeignKey(bi => bi.TratamentoId);

        modelBuilder.Entity<TratamentoDente>()
            .HasOne(b => b.Dente)
            .WithMany(ba => ba.TratamentoDentes)
            .HasForeignKey(bi => bi.DenteId);


        modelBuilder.Entity<DenteProcedimento>()
                .HasOne(b => b.Tratamento)
                .WithMany(ba => ba.DenteProcedimentos)
                .HasForeignKey(bi => bi.TratamentoId);

        modelBuilder.Entity<DenteProcedimento>()
            .HasOne(b => b.Procediment)
            .WithMany(ba => ba.DenteProcedimentos)
            .HasForeignKey(bi => bi.ProcedimentId);
    }
    */
      
        public DbSet<Dente> Dente { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Procediment> Procediment { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tratamento> Tratamento { get; set; }
        public DbSet<TipoServico> TipoServico { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        //public DbSet<TratamentoDente> TratamentoDentes { get; set; }
        //public DbSet<DenteProcedimento> DenteProcedimentos { get; set; }
}
