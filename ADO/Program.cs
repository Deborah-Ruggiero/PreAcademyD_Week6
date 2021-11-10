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
                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 6));

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
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                       
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }
    }
}
