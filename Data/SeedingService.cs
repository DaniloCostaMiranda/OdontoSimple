using System;
using System.Linq;
using OdontoSimple.Models;

namespace OdontoSimple.Data
{
    public class SeedingService
    {
        private OdontoSimpleContext _context;

        public SeedingService(OdontoSimpleContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Dente.Any() ||
                _context.Paciente.Any() ||
                _context.TipoServico.Any() ||
                _context.Status.Any() ||
                _context.Tratamento.Any() ||
                _context.Procediment.Any()
                )
            {
                return; 
            }

            Dente d1 = new Dente(1, 13, "Incisivo");
            Dente d2 = new Dente(2, 23, "Molar");

            Paciente pa1 = new Paciente(1, "Bob Brown", 71991790397, "bob@gmail.com", "rua duarte, 51");
            Paciente pa2 = new Paciente(2, "Jorge Luiz", 7199900876, "horge@gmail.com", "alameda padua, 25");

            TipoServico t1 = new TipoServico(1, "Stética");
            TipoServico t2 = new TipoServico(2, "Odontologia");

            Status u1 = new Status(1, "Aberto");
            Status u2 = new Status(2, "Fechado");

            Procediment pr1 = new Procediment(1, "Aberto", 50.50);
            Procediment pr2 = new Procediment(2, "Fechado", 30.50);

            Tratamento tr1 = new Tratamento(1, new DateTime(1986, 3, 27), "Tylenol", "Raio RX", d2);
            Tratamento tr2 = new Tratamento(2, new DateTime(1983, 5, 25), "Dipirona", "Ultrassom", d1);

            _context.Dente.AddRange(d1, d2);
            _context.Paciente.AddRange(pa1, pa2);
            _context.TipoServico.AddRange(t1, t2);
            _context.Status.AddRange(u1, u2);
            _context.Procediment.AddRange(pr1, pr2);
            _context.Tratamento.AddRange(tr1, tr2);

            _context.SaveChanges();

        }
    }
}

