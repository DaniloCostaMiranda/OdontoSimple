using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}, tamanho da descricao deve ser entre {2} e {1} caracteres")]
        public string Telefone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "{0} mandatória")]
        [EmailAddress(ErrorMessage = "e-mail requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        public string Endereco { get; set; }

        //[ForeignKey("Tratamento")]
        //public int? TratamentoId { get; set; }


        //public virtual Tratamento Tratamento { get; set; }

        
        public Profissional()
        {
            
        }

        public Profissional(int id, string nome, string telefone, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
        
    }


}
