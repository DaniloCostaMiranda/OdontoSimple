using System;
using System.Collections.Generic;

namespace OdontoSimple.Models.ViewModels
{
    public class TratamentoFormViewModel
    {
        public Tratamento Tratamento { get; set; }
        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public ICollection<Dente> Dentes { get; set; }
        //public ICollection<Procediment> Procediments { get; set; }
        //public ICollection<Status> Statuss { get; set; }
        //public ICollection<TipoServico> TipoServicos { get; set; }

    }
}
