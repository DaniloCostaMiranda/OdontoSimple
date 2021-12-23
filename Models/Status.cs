using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} mandatória")]
        [Display(Name = "Status do tratamento")]
        public string StatusAtual { get; set; }

        //[ForeignKey("Tratamento")]
        //public int? TratamentoId { get; set; }


        //public virtual Tratamento Tratamento { get; set; }


        
        public Status()
        {

        }

        public Status(int id, string statusAtual)
        {
            Id = id;
            StatusAtual = statusAtual;
        }
        
    }

}
