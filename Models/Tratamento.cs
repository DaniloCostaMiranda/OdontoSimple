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

        /*
        [ForeignKey("DenteId")]
        public virtual Dente Dente { get; set; }
        public int DenteId { get; set; }

        [ForeignKey("ProcedimentId")]
        public virtual Procediment Procediment { get; set; }
        public int ProcedimentId { get; set; }
        */

        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0}, tamanho da descricao deve ser entre {2} e {1} caracteres")]
        public string Medicamentos { get; set; }

        public string Exames { get; set; }

        //[ForeignKey("TratamentoId")]
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

      
        public Profissional Profissional { get; set; }
        public int ProfissionalId { get; set; }
        

        
        public Dente Dente { get; set; }
        public int DenteId { get; set; }

        
        public Procediment Procediment { get; set; }
        public int ProcedimentId { get; set; }

        //[ForeignKey("TratamentoId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }

        //[ForeignKey("TratamentoId")]
        public TipoServico TipoServico { get; set; }
        public int TipoServicoId { get; set; }


        
       public Tratamento()
       {

       }

       public Tratamento(int id, DateTime data, Status status, TipoServico tipoServico, Dente dente, Procediment procediment, Paciente paciente, Profissional profissional, string medicamentos, string exames )
       {
           Id = id;
           Data = data;
           Status = status;
           TipoServico = tipoServico;
           Dente = dente;
           Procediment = procediment;
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
