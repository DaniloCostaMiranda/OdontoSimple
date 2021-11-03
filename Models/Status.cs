using System;
using System.ComponentModel.DataAnnotations;

namespace OdontoSimple.Models
{
    public class Status
    {
        public int Id { get; set; }


        [Display(Name = "Status do tratamento")]
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
