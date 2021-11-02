using System;
using System.ComponentModel.DataAnnotations;

namespace OdontoSimple.Models
{
    public class Procediment
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }
        

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
