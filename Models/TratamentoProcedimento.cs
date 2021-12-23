using System;
namespace OdontoSimple.Models
{
    public class TratamentoProcedimento
    {
        public int Id { get; set; }

        public int TratamentoId { get; set; }
        public virtual Tratamento Tratamento { get; set; }

        public int ProcedimentId { get; set; }
        public virtual Procediment Procediment { get; set; }

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
