using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class Procediment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }


        public List<DenteProcedimento> DenteProcedimentos { get; set; } = new List<DenteProcedimento>();
        //public List<TratamentoProcedimento> TratamentoProcedimentos { get; set; }



        public Procediment()
        {

        }

        public Procediment(int id, string nome, double valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
           
        }
        
    }
}
