using System;
using System.Collections.Generic;

namespace Azienda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stagista s = new Stagista("Renata", "Carriero");
            //s.StampaStipendio();
            //s.StampaRuolo();
            //s.StampaFerie();
            //Console.WriteLine(s.GetType());

            Tecnico t = new Tecnico("Mario", "Rossi", "cfmariuorossi");
            Manager m = new Manager("Giuseppe", "Bianchi", "cfgiuseppebianchi", 20);
            
            List<Dipendente> dipendentiAzienda = new List<Dipendente>();

            dipendentiAzienda.Add(m);
            dipendentiAzienda.Add(s);
            dipendentiAzienda.Add(t);

            foreach (var item in dipendentiAzienda)
            {
                item.StampaDatiAnagrafici();
                item.StampaRuolo();
                item.StampaStipendio();
                item.StampaFerie();
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
