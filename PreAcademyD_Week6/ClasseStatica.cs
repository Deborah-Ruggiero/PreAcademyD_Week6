using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAcademyD_Week6
{
    static class ClasseStatica
    {
        public static string Nome { get; set; } = "Nome della Classe statica";
        public static List<string> parole { get; set; } = new List<string>() { "parola1", "parola2", "parola3" };
        
        

        public static void SalutaDaClasseStatica()
        {
            Console.WriteLine("Ciaone!!!");
                     
        }

          
    }
}
