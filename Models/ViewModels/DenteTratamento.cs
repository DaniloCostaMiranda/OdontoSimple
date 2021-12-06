using System;
using System.Collections.Generic;

namespace OdontoSimple.Models.ViewModels
{
    public class DenteTratamentoViewModel
    {
        public int TratamentoId { get; set; }
        public int DenteId { get; set; }
        public ICollection<int> ProcedimentId { get; set; } = new List<int>();

        //public Dente Dente { get; set; }
        public ICollection<Dente> Dentes { get; set; } = new List<Dente>();
        public ICollection<Procediment> Procediments { get; set; } = new List<Procediment>();
    }
}
