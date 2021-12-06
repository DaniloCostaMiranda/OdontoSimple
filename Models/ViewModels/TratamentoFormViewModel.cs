using System;
using System.Collections.Generic;

namespace OdontoSimple.Models.ViewModels
{
    public class TratamentoFormViewModel
    {
        public Tratamento Tratamento { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        public ICollection<Profissional> Profissionals { get; set; }
        //public int TratamentoId { get; set; }
        //public int DenteId { get; set; }
        public ICollection<int> ProcedimentId { get; set; } = new List<int>();
        public Dente Dente { get; set; }
        public ICollection<Dente> Dentes { get; set; } = new List<Dente>();
        public ICollection<Procediment> Procediments { get; set; } = new List<Procediment>();
        public ICollection<Status> Statuss { get; set; }
        public ICollection<TipoServico> TipoServicos { get; set; }
        //public ICollection<TratamentoDente> TratamentoDentes { get; set; } = new List<TratamentoDente>();
        //public ICollection<int> TratamentoDentesId { get; set; } = new List<int>();
        //public ICollection<DenteProcedimento> DenteProcedimentos { get; set; } = new List<DenteProcedimento>();
        //public ICollection<int> DenteProcedimentosId { get; set; } = new List<int>();


    }
}
