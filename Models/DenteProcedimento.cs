using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class DenteProcedimento
    {
       
            public int Id { get; set; }

        public int TratamentoId { get; set; }
        [ForeignKey("TratamentoId")]
        public virtual Tratamento Tratamento { get; set; }

        public int ProcedimentId { get; set; }
        [ForeignKey("ProcedimentId")]
        public virtual Procediment Procediment { get; set; }
            

            public DenteProcedimento()
            {
            }

            public DenteProcedimento(int id, Tratamento tratamento, int tratamentoId, Procediment procediment, int procedimentId)
            {
                Id = id;
                Tratamento = tratamento;
                TratamentoId = tratamentoId;
                Procediment = procediment;
                ProcedimentId = procedimentId;
            }
        
    }
}
