using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Rettangolo : Forma
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public Rettangolo(double b, double h)
        {
            Base = b;
            Altezza = h;
            IsQuadrilatero = true;
        }

        public override double CalcolaArea()
        {
            return Base * Altezza;
        }

        public override double CalcolaPerimetro()
        {
            return (Base+ Altezza)*2; 
        }

        public override string ToString()
        {
            return $"Rettangolo: base={Base} \tAltezza={Altezza}";
        }


        public override bool Equals(object obj)
        {
            Rettangolo r = (Rettangolo)obj;
            if (r == null)
            {
                return false;
            }
            return Base == r.Base && Altezza == r.Altezza;
        }

    }
}
