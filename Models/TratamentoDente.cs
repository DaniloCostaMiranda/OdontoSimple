using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class TratamentoDente
    {
        public int Id { get; set; }
        
        public int TratamentoId { get; set; }
        [ForeignKey("TratamentoId")]
        public virtual Tratamento Tratamento { get; set; }

        public int DenteId { get; set; }
        [ForeignKey("DenteId")]
        public virtual Dente Dente { get; set; }

        public TratamentoDente()
        {
        }

        public TratamentoDente(int id, Tratamento tratamento, int tratamentoId, Dente dente, int denteId)
        {
            Id = id;
            Tratamento = tratamento;
            TratamentoId = tratamentoId;
            Dente = dente;
            DenteId = denteId;
        }
    }

   
}
