using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcio
{
    static class SquadraManager
    {

        public static void AddCalciatore(Calciatore c, List<Calciatore> squadra)
        {
            if (PossoInserirlo(c, squadra))
            {
                squadra.Add(c);
            }
            else
            {
                Console.WriteLine($"Raggiunto numero massimo di {c.Ruolo}");
            }
        }

        private static bool PossoInserirlo(Calciatore c, List<Calciatore> squadra)
        {
            var numeroRuoliPerSquadra = new Dictionary<Ruolo, int>
            {
                {Ruolo.Attaccante, 2 },
                {Ruolo.Centrocampista, 4 },
                {Ruolo.Difensore, 4 },
                {Ruolo.Portiere,1 }
            };

            int count = 0;
            foreach (var item in squadra)
            {
                if (item.Ruolo == c.Ruolo)
                {
                    count++;
                }
            }

            if(count < numeroRuoliPerSquadra[c.Ruolo])
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
