using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OdontoSimple.Models
{
    public class Dente
    {
        public int Id { get; set; }

        [Display(Name = "Número do Dente")]
        public int Numero { get; set; }
        public string Nome { get; set; }

        //[ForeignKey("Tratamento")]
        //public int? TratamentoId { get; set; }

        //public virtual Tratamento Tratamento { get; set; }

        public List<TratamentoDente> TratamentoDentes { get; set; } = new List<TratamentoDente>();

        public List<DenteProcedimento> DenteProcedimentos { get; set; } = new List<DenteProcedimento>();

        public List<Procediment> Procediments { get; set; } = new List<Procediment>();
        [NotMapped] public List<int> ProcedimentsId { get; set; } = new List<int>();

        public Dente()
        {
        }

        public Dente(int id, int numero, string nome)
        {
            Id = id;
            Numero = numero;
            Nome = nome;
        }

        /*
        public void AddProcediment(Procediment pr)
        {
            Procediments.Add(pr);
        }

        public void RemoveProcediment(Procediment pr)
        {
            Procediments.Remove(pr);
        }

        public double TotalProcediment()
        {
            return Procediments.Sum(x => x.Valor);
        }
        */
    }
}
