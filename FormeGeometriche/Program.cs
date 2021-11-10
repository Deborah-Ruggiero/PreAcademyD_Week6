using System;
using System.Collections.Generic;

namespace FormeGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            //EsempioEquals();

            Console.WriteLine("Figure geometriche");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("--------------------------------Menu----------------------------");
                Console.WriteLine("1. Inserisci figura geometrica");
                Console.WriteLine("2. Stamapa figure geometriche della lista");
                Console.WriteLine("3. Stamapa perimetro di tutte le figure geometriche della lista");
                Console.WriteLine("4. Stamapa area di tutte le figure geometriche della lista");
                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Seleziona una tra le possibili opzioni");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        InserisciFigura();
                        break;
                    case 2:
                        StampaFigure();
                        break;
                    case 3:
                        StampaPerimetroFigure();
                        break;
                    case 4:
                        StampaAreaFigure();
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static void EsempioEquals()
        {
            int i = 4;
            int j = 4;
            Console.WriteLine("Confronto tra interi");
            Console.WriteLine($"Confronto con l uguale: {i == j}");
            Console.WriteLine($"Confronto con metodo Equals: {i.Equals(j)}");

            string s1 = "Ciao";
            string s2 = "Ciao";
            Console.WriteLine("Confronto tra stringhe");
            Console.WriteLine($"Confronto con l uguale: {s1 == s2}");
            Console.WriteLine($"Confronto con metodo Equals: {s1.Equals(s2)}");

            Rettangolo r1 = new Rettangolo(10, 2);
            Rettangolo r2 = new Rettangolo(10, 2);
            
            Console.WriteLine("Confronto tra Rettangoli (o in generale tra tipi definiti dall utente)");
            Console.WriteLine($"Confronto con l uguale: {r1 == r2}"); //falso
            Console.WriteLine($"Confronto con metodo Equals: {r1.Equals(r2)}"); //falso

            Rettangolo r3 = r1;
            Console.WriteLine($"\nConfronto con l uguale: {r1 == r3}"); //vero
            Console.WriteLine($"\nConfronto con metodo Equals: {r1.Equals(r3)}"); //vero

            int[] arrayDiInteri = new[] { 10, 3, 2, 1, 20 };
            
            Array.Sort(arrayDiInteri);
            foreach (var item in arrayDiInteri)
            {
                Console.WriteLine(item);
            }

            Array.Reverse(arrayDiInteri);
            foreach (var item in arrayDiInteri)
            {
                Console.WriteLine(item);
            }
        }

        private static void StampaAreaFigure()
        {
            if (FormeManager.formeGeometriche.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("\nEcco i Perimetri delle figure presenti nella lista:\n");
                foreach (var item in FormeManager.formeGeometriche)
                {
                    Console.WriteLine($"{item.ToString()} - Area: {item.CalcolaArea()}");
                }
            }
        }
        private static void StampaPerimetroFigure()
        {
            if (FormeManager.formeGeometriche.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("\nEcco i Perimetri delle figure presenti nella lista:\n");
                foreach (var item in FormeManager.formeGeometriche)
                {
                    Console.WriteLine($"{item.ToString()} - Perimetro: {item.CalcolaPerimetro()}");
                }
            }
        }
        private static void StampaFigure()
        {
            if (FormeManager.formeGeometriche.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("\nEcco le figure presenti nella lista:\n");
                foreach (var item in FormeManager.formeGeometriche)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void InserisciFigura()
        {
            Console.WriteLine("1.Rettangolo");
            Console.WriteLine("2.Quadrato");
            Console.WriteLine("3.Triangolo");
            Console.WriteLine("4.Cerchio");
            int scelta;
            do
            {
                Console.WriteLine("Quale figura vuoi inserire?");
            } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 1 && scelta <= 4));

            switch (scelta)
            {
                case 1:
                    Rettangolo r = (Rettangolo)CreaRettangolo();
                    FormeManager.AddFigura(r);
                    break;
                case 2:
                    Quadrato q = (Quadrato)CreaQuadrato();
                    FormeManager.AddFigura(q);
                    break;
                case 3:
                    Triangolo t = (Triangolo)CreaTriangolo();
                    FormeManager.AddFigura(t);
                    break;
                case 4:
                    Cerchio c = (Cerchio)CreaCerchio();
                    FormeManager.AddFigura(c);
                    break;
            }
        }
        public static Forma CreaRettangolo()
        {
            Console.WriteLine("Crea il tuo rettangolo");
            Console.WriteLine("Inserisci il valore della base");
            double b;
            while (!(double.TryParse(Console.ReadLine(), out b) && b > 0))
            {
                Console.WriteLine("Valore errato");
            }

            Console.WriteLine("Inserisci il valore dell''altezza");
            double h;
            while (!(double.TryParse(Console.ReadLine(), out h) && h > 0))
            {
                Console.WriteLine("Valore errato");
            }

            return new Rettangolo(b, h);
        }
        public static Forma CreaQuadrato()
        {
            Console.WriteLine("Crea il tuo Quadrato");
            Console.WriteLine("Inserisci il valore del lato");
            double l;
            while (!(double.TryParse(Console.ReadLine(), out l) && l > 0))
            {
                Console.WriteLine("Valore errato");
            }
            return new Quadrato(l);
        }
        public static Forma CreaTriangolo()
        {
            Console.WriteLine("Crea il tuo Triangolo");
            Console.WriteLine("Inserisci il valore della base");
            double b;
            while (!(double.TryParse(Console.ReadLine(), out b) && b > 0))
            {
                Console.WriteLine("Valore errato");
            }

            Console.WriteLine("Inserisci il valore dell''altezza");
            double h;
            while (!(double.TryParse(Console.ReadLine(), out h) && h > 0))
            {
                Console.WriteLine("Valore errato");
            }
            Console.WriteLine("Inserisci il valore del cateto1");
            double c1;
            while (!(double.TryParse(Console.ReadLine(), out c1) && c1 > 0))
            {
                Console.WriteLine("Valore errato");
            }
            Console.WriteLine("Inserisci il valore del cateto2");
            double c2;
            while (!(double.TryParse(Console.ReadLine(), out c2) && c2 > 0))
            {
                Console.WriteLine("Valore errato");
            }
            return new Triangolo(b, h, c1, c2);
        }
        public static Forma CreaCerchio()
        {
            Console.WriteLine("Crea il tuo Cerchio");
            Console.WriteLine("Inserisci il valore del raggio");
            double r;
            while (!(double.TryParse(Console.ReadLine(), out r) && r > 0))
            {
                Console.WriteLine("Valore errato");
            }
            return new Cerchio(r);
        }

    }
}
