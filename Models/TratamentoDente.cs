using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class TratamentoDente
    {
        public int Id { get; set; }

        public int TratamentoId { get; set; }
        public virtual Tratamento Tratamento { get; set; }

        public int DenteId { get; set; }
        public virtual Dente Dente { get; set; }

        public List<DenteProcedimento> DenteProcedimentos { get; set; } = new List<DenteProcedimento>();

        /*
        public TratamentoProcedimento()
        {

        }
        
        public TratamentoProcedimento(Tratamento tratamento, Procediment procediment)
        {
            Tratamento = tratamento;
            Procediment = procediment;
        }
        */
    }



}
