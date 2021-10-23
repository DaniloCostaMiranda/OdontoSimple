using System;
using System.Collections.Generic;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Models
{
    public class Tratamento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }
        public string Medicamentos { get; set; }
        public string Exames { get; set; }
        public TipoServico TipoServico { get; set; }
        public ICollection<Dente> Dentes { get; set; } = new List<Dente>();

        public Tratamento()
        {

        }

        public Tratamento(int id, Paciente paciente, DateTime data, Status status, string medicamentos, string exames, TipoServico tipoServico)
        {
            Id = id;
            Paciente = paciente;
            Data = data;
            Status = status;
            Medicamentos = medicamentos;
            Exames = exames;
            TipoServico = tipoServico;
        }

        public void AddDente(Dente dente)
        {
            Dentes.Add(dente);
        }

        public void RemoveDente(Dente dente)
        {
            Dentes.Remove(dente);
        }

        public double TotalTratamento(Procediment procediment)
        {
            return Dentes.SelectMany(x => x.Procediments).Sum(x => x.Valor);
        }

    }
}
