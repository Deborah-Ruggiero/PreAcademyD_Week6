using System;

namespace Esercizietti
{
    class Program
    {
        static void Main(string[] args)
        {
            //Esercizio 1: Trovare quante volte un certo carattere è contenuto in una stringa
            Esercizio1();


            //Esercizio 2: Data una stringa, scrivere un programma che trova il primo carattere non ripetuto.
            //es. mozzarella -> output m
            //es. sottilissimo -> output l
            Esercizio2();

        }



        private static void Esercizio1()
        {
            Console.WriteLine("Inserisci una parola/frase: ");
            string s = Console.ReadLine();
            //string s = "banana";
            Console.WriteLine("Scegli una lettera e ti dirò quante volte è contenuta nella parola/frase che hai inserito!");
            char toFind = Console.ReadKey().KeyChar;
            //char toFind = 'n';

            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (toFind == s[i])
                {
                    total++;
                }
            }
            Console.WriteLine($"\n\nLa lettera {toFind} è contenuta {total} volte nella parola/frase '{s}'");
        }

        private static void Esercizio2()
        {
            string word = "ekelk";
            for (int i = 0; i < word.Length; i++)
            {
                int conta = ContaOccorrenze(word, word[i]);
                if (conta == 1)
                {
                    Console.WriteLine($"Il primo carattere non ripetuto è {word[i]}");
                    break;
                }
            }
        }

        //Ho scritto questa funzione che praticamente fa la stessa cosa dell'esercizio 1
        //ma prende in input la parola e il carattere
        //e restituisce quante volte il carattere è ripetuto nella parola.
        private static int ContaOccorrenze(string s, char toFind)
        {
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (toFind == s[i])
                {
                    total++;
                }
            }
            return total;
        }
    }
}
