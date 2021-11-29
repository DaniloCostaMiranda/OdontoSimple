using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class TipoServico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        [Display(Name = "Tipo do Atendimento")]
        public string Nome { get; set; }

        //[ForeignKey("Tratamento")]
        //public int? TratamentoId { get; set; }


        //public virtual Tratamento Tratamento { get; set; }

        
        TipoServico()
        {

        }

        public TipoServico(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        
    }
}
