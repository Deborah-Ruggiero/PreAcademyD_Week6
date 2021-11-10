using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    static class FormeManager
    {
        public static List<Forma> formeGeometriche = new List<Forma>();

        internal static void AddFigura(Forma figura)
        {
            //Controllo se nella lista esiste già una figura uguale , ovvero dello stesso tipo e con dati uguali.
            foreach (var item in formeGeometriche)
            {
                if (figura.Equals(item))
                {
                    Console.WriteLine("Esiste già una figura uguale nella lista!");
                    return;
                }
            }
            formeGeometriche.Add(figura);
        }
        ////Con Generics
        //internal static void AddFigura<T>(T figura) where T : Forma
        //{
        //    formeGeometriche.Add(figura);
        //}
    }
}
