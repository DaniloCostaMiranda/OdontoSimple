using System;
namespace OdontoSimple.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string StatusAtual { get; set; }

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
