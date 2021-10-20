using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdontoSimple.Models
{
    public class OdontoSimpleContext : DbContext
    {
        public OdontoSimpleContext (DbContextOptions<OdontoSimpleContext> options)
            : base(options)
        {
        }

        public DbSet<OdontoSimple.Models.Procedimento> Procedimento { get; set; }
    }
}
