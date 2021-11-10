using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azienda
{
    public class Manager : Tecnico
    {
        public int BonusMensile { get; set; } = 1000;

        public Manager(string nome, string cognome, string codiceFiscale)
           : base(nome, cognome, codiceFiscale)
        {

        }
        public Manager(string nome, string cognome, string codiceFiscale, int pagaOraria)
            :base(nome, cognome, codiceFiscale, pagaOraria)
        {

        }

        public Manager(string nome, string cognome, string codiceFiscale, int pagaOraria, int bonus)
            : base(nome, cognome, codiceFiscale, pagaOraria)
        {
            BonusMensile = bonus;
        }
        private new int CalcolaStipendio()
        {
            return base.CalcolaStipendio() + BonusMensile;
        }


        public override void StampaStipendio()
        {
            //Console.WriteLine($"Lo stipendio è: {CalcolaStipendio()+BonusMensile}");
            Console.WriteLine($"Lo stipendio è: {CalcolaStipendio()}");
        }

        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Manager");
        }

        public override void StampaFerie()
        {
            Console.WriteLine("Il manager ha 3 giorni di ferie");
        }

    }
}
