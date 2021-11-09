using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    class Stagista : Dipendente
    {
        public int CompensoMensile { get; set; } = 600;

        public Stagista(string nome, string cognome):base(nome, cognome)
        {
            
        }

        public Stagista(string nome, string cognome, int compensoMensile) : base(nome, cognome)
        {
            CompensoMensile = compensoMensile;
        }

        public override void StampaStipendio()
        {
            Console.WriteLine($"Lo stipendio è di {CompensoMensile}");
            //Console.WriteLine("Lo stipendio dello stagista {1} {0} è di {2}", Nome, Cognome, CompensoMensile);
        }

        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Stagista ");
        }

        public override void StampaFerie()
        {
            Console.WriteLine("Lo stagista ha 5 giorni di ferie");
        }
    }
}
