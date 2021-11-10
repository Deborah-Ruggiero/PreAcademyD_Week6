using System;

namespace ADO
{
    class Program
    {
        // L'utente può:
        // Vedere tutti i film nella videoteca
        // Cercere i film per genere
        // Cercare i film per titolo
        // Cercare i film che hanno una durata minore di tot minuti
        // Cercare i film di un genere che hanno anche una durata maggiore di tot minuti
        // Stampare il numero di film nella videoteca

        // Far scegliere all'utente i soli generi presenti
        // oppure gestire se non trova film con il genere inserito
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella Videoteca!");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("--------------------------------Menu----------------------------");
                Console.WriteLine("1. Stampa film della videoteca");
                Console.WriteLine("2. Cerca film per genere");
                Console.WriteLine("3. Cerca film per titolo");
                Console.WriteLine("4. Cerca i film che hanno una durata minore di tot minuti");
                Console.WriteLine("5. Cerca i film di un genere che hanno anche una durata maggiore di tot minuti");
                Console.WriteLine("6. Stampare il numero di film nella videoteca");
                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 6));

                switch (scelta)
                {
                    case 1:
                        StampaTuttiIFilm();
                        break;
                    case 2:
                        CercaFilmPerGenere();
                        break;
                    case 3:
                        CercaFilmPerTitolo();
                        break;
                    case 4:
                        CercaFilmPerDurataMinoreDi();
                        break;
                    case 5:
                        CercaFilmPerGenereEDurataMaggioreDi();
                        break;
                    case 6:
                        StampaNumeroFilm();
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static void StampaNumeroFilm()
        {
            throw new NotImplementedException();
        }

        private static void CercaFilmPerGenereEDurataMaggioreDi()
        {
            throw new NotImplementedException();
        }

        private static void CercaFilmPerDurataMinoreDi()
        {
            throw new NotImplementedException();
        }

        private static void CercaFilmPerTitolo()
        {
            throw new NotImplementedException();
        }

        private static void CercaFilmPerGenere()
        {
            throw new NotImplementedException();
        }

        private static void StampaTuttiIFilm()
        {
            throw new NotImplementedException();
        }
    }
  
}
