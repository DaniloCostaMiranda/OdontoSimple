using System;
namespace OdontoSimple.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public Paciente()
        {
        }

        public Paciente(int id, string nome, long telefone, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }

}
