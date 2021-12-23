using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} mandatória")]
        public string Nome { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}, tamanho da descricao deve ser entre {2} e {1} caracteres")]
        public string Telefone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} mandatória")]
        [EmailAddress(ErrorMessage = "e-mail requerido")]
        public string Email { get; set; }
        public string Endereco { get; set; }

        //[ForeignKey("Tratamento")]
        //public int? TratamentoId { get; set; }

        
        //public virtual Tratamento Tratamento { get; set; }

        
        public Paciente()
        {
        }

        public Paciente(int id, string nome, string telefone, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
        
    }

}
