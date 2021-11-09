using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Tecnico : Dipendente
    {
        public string  CodiceFiscale { get; set; }

        public int PagaOraria { get; set; } = 10;

        public Tecnico(string nome, string cognome, string codiceFiscale): base(nome, cognome)
        {
            CodiceFiscale = codiceFiscale;
        }
        public Tecnico(string nome, string cognome, string codiceFiscale, int pagaOraria) : base(nome, cognome)
        {
            CodiceFiscale = codiceFiscale;
            PagaOraria = pagaOraria;
        }

        protected int CalcolaStipendio()
        {
            //int stipendio = 26 * 8 * PagaOraria;
            //return stipendio;
            return 26 * 8 * PagaOraria;
        } 

        public override void StampaStipendio()
        {
            Console.WriteLine($"Lo stipendio è: {CalcolaStipendio()}");
        }

        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Tecnico");
        }

        public override void StampaFerie()
        {
            Console.WriteLine("Il tecnico ha 4 giorni di ferie");
        }
    }
}
