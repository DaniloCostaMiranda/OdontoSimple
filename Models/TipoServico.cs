using System;
using System.ComponentModel.DataAnnotations;

namespace OdontoSimple.Models
{
    public class TipoServico
    {
        public int Id { get; set; }

        [Display(Name = "Tipo do Atendimento")]
        public string Nome { get; set; }

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
