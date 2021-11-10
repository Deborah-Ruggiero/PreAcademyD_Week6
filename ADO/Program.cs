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
            //DbManagerMock db = new DbManagerMock();
            DbManager db = new DbManager();

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
                Console.WriteLine("7. Inserisci un nuovo Film");

                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 7));

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("I Film presenti nella videoteca sono:\n");
                        db.GetAllFilms();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il genere da ricercare:\n");
                        string genereScelto = Console.ReadLine();
                        db.GetFilmByGenere(genereScelto);
                        break;
                    case 3:
                        Console.WriteLine("Inserisci il Titolo da ricercare:\n");
                        string titolo = Console.ReadLine();
                        db.GetFilmByTitolo(titolo);
                        break;
                    case 4:
                        int durata;
                        Console.WriteLine("Inserisci la durata Max. (Ti verranno restituiti i film con durano di meno):\n");
                        
                        while(!(int.TryParse(Console.ReadLine(), out durata) && durata > 0))
                        {
                            Console.WriteLine("Valore errato. Riprova:");
                        }
                        db.GetFilmByDurataMax(durata);
                        break;
                    case 5:
                        Console.WriteLine("Inserisci il genere da ricercare:\n");
                        string genere = Console.ReadLine();
                        int d;
                        Console.WriteLine("Inserisci la durata Min:\n");

                        while (!(int.TryParse(Console.ReadLine(), out d) && d > 0))
                        {
                            Console.WriteLine("Valore errato. Riprova:");
                        }
                        db.GetFilmByGenereEDurataMin(genere, d);
                        break;
                    case 6:
                        db.GetNumeroDiFilm();
                        break;
                    case 7:
                        Console.WriteLine("Inserisci il Titolo del nuovo Film");
                        string t = Console.ReadLine();
                        Console.WriteLine("Inserisci il genere del nuovo Film");
                        string g = Console.ReadLine();
                        int d1;
                        Console.WriteLine("Inserisci la durata del nuovo film:\n");

                        while (!(int.TryParse(Console.ReadLine(), out d1) && d1 > 0))
                        {
                            Console.WriteLine("Valore errato. Riprova:");
                        }
                        db.InserisciFilm(t,g,d1);
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }
    }
}
