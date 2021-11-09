using System;
using System.Collections.Generic;

namespace Calcio
{
    // gli atleti hanno nome, cognome, età

    // Calciatori hannno ruolo e numero maglia(ruoli = centrocampista e difensore portiere e attaccante)

    // Portieri hanno di default il numero maglia = 1 e il numero gol subiti

    // gli attaccanti hanno il numero gol fatti a partita

    // Una squadra di calcio è formata da 11 calciatori di cui
    // un portiere
    // 4 difensori
    // 4 centrocampisti
    // 2 attaccanti

    //Per svolgere una partita serve anche un arbitro(l'arbitro è un atleta)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcio");
            List<Calciatore> squadra1 = new List<Calciatore>();


            Portiere p = new Portiere("Antonio", "Donnarumma", 20);
            Calciatore d1 = new Calciatore("Alessio", "Romagnoli", 22, 13, Ruolo.Difensore);
            Calciatore c1 = new Calciatore("Sandro", "Tonali", 30, 8, Ruolo.Centrocampista);
            Attaccante a = new Attaccante("Daniel", "Maldini", 25, 20);

            SquadraManager.AddCalciatore(a, squadra1);
            SquadraManager.AddCalciatore(c1, squadra1);
            SquadraManager.AddCalciatore(d1, squadra1);
            SquadraManager.AddCalciatore(p, squadra1);

            Console.WriteLine("La formazione della squadra1 è:");
            foreach (var item in squadra1)
            {
                Console.WriteLine(item.ToString());
            }

            Portiere p1 = new Portiere("Gigi", "Buffon", 40);
            SquadraManager.AddCalciatore(p1, squadra1);

        }
    }
}
