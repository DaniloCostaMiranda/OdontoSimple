using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Models
{
    public class Tratamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} mandatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

  
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0}, tamanho da descricao deve ser entre {2} e {1} caracteres")]
        public string Medicamentos { get; set; }

        public string Exames { get; set; }

        
        public virtual Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

      
        public virtual Profissional Profissional { get; set; }
        public int ProfissionalId { get; set; }
        

        public virtual Status Status { get; set; }
        public int StatusId { get; set; }

        
        public virtual TipoServico TipoServico { get; set; }
        public int TipoServicoId { get; set; }

        public List<TratamentoDente> TratamentoDentes { get; set; } = new List<TratamentoDente>();

        public List<Dente> Dentes { get; set; } = new List<Dente>();
        [NotMapped]public List<int> DentesId { get; set; } = new List<int>();

        
        /*
        public List<TratamentoProcedimento> TratamentoProcedimentos { get; set; } = new List<TratamentoProcedimento>();

        public List<Procediment> Procediments { get; set; } = new List<Procediment>();
        [NotMapped]public List<int> ProcedimentsId { get; set; } = new List<int>();
        */

        //public Procediment Procediment { get; set; }
        //public int ProcedimentId { get; set; }

        //public virtual Dente Dente { get; set; }

        //public int DenteId { get; set; }

        /*
        [ForeignKey("DenteId")]
        public virtual Dente Dente { get; set; }
        public int DenteId { get; set; }

        [ForeignKey("ProcedimentId")]
        public virtual Procediment Procediment { get; set; }
        public int ProcedimentId { get; set; }
        */

        public Tratamento()
       {

       }

       public Tratamento(int id, DateTime data, Status status, TipoServico tipoServico, Dente dente, Procediment procediment, Paciente paciente, Profissional profissional, string medicamentos, string exames )
       {
           Id = id;
           Data = data;
           Status = status;
           TipoServico = tipoServico;
           //Dente = dente;
           //Procediment = procediment;
           Medicamentos = medicamentos;
           Exames = exames;
           Paciente = paciente;
           Profissional = profissional;


       }

        /*
       public void AddDente(Dente dente)
       {
           Dentes.Add(dente);
       }

       public void RemoveDente(Dente dente)
       {
           Dentes.Remove(dente);
       }

       public double TotalTratamento()
       {
           return Dentes.SelectMany(x => x.Procediments).Sum(x => x.Valor);
       }*/

    }
}
