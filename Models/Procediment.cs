using System;
namespace OdontoSimple.Models
{
    public class Procediment
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Status Status { get; set; }

        public Procediment()
        {

        }

        public Procediment(int id, string nome, double valor, Status status)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Status = status;
        }
    }
}
