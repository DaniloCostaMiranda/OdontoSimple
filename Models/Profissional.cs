using System;
using System.Collections.Generic;

namespace OdontoSimple.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public ICollection<Tratamento> Tratamentos { get; set; } = new List<Tratamento>();

        public Profissional()
        {
            
        }

        public Profissional(int id, string nome, long telefone, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }


}
