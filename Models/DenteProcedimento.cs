using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdontoSimple.Models
{
    public class DenteProcedimento
    {

        public int Id { get; set; }

        public int TratamentoDenteId { get; set; }
        public virtual TratamentoDente TratamentoDente { get; set; }

        public int ProcedimentId { get; set; }
        public virtual Procediment Procediment { get; set; }

    }
}
