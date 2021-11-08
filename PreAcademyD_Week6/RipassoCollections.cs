using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PreAcademyD_Week6
{
    class RipassoCollections
    {
       
        public void Ripasso()
        {
            Console.WriteLine("Hello World!");
            string a;
            int i = 1;
            var j = 1.6;

            //Array
            var nomi = new string[]
            {
                "Renata",
                "Alessandra",
                "Valentina"
            };

            //Collections
            //ArrayList
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(2);
            myArrayList.Add("Ciao");
            myArrayList.Add(10);
            myArrayList.Add("Renata");

            int numeroElementi = myArrayList.Count;
            Console.WriteLine($"Il mio arrayList contiene {numeroElementi} elementi");

            Hashtable table = new Hashtable();
            table.Add(1, "uno");
            table.Add(2, 2000);
            table.Add("oggi", DateTime.Today.ToShortDateString());

            //Collection Generics
            List<string> listaNomi = new List<string>();
            listaNomi.Add("Renata");
            listaNomi.Add("Alessandra");
            listaNomi.Add("Valentina");

            foreach (var item in listaNomi)
            {
                Console.WriteLine($"{item}");
            }

            listaNomi.Insert(1, "Pippo");
            Console.WriteLine("Stampa dopo l'aggiunta di Pippo in posizione 1");
            foreach (var item in listaNomi)
            {
                Console.WriteLine($"{item}");
            }

            var festività = new Dictionary<string, DateTime>();
            festività.Add("Natale", new DateTime(2021, 12, 25));
            festività.Add("Capodanno", new DateTime(2021, 01, 01));

            var ragazze = new Dictionary<string, int>()
            {
                ["Renata"] = 34,
                ["Valentina"] = 33,
                ["Tatiana"] = DateTime.Today.Year - 1988
            };
            //ragazze.Add("Renata", 34);


            foreach (var item in ragazze)
            {
                Console.WriteLine($"Chiave: {item.Key} \t Valore: {item.Value}");
            }
        }
    }
}
