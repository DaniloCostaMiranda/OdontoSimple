using System;
namespace OdontoSimple.Models
{
    public class TipoServico
    {
        public int Id { get; set; }
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
