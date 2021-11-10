using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Triangolo: Forma
    {
        public double Base { get; set; }
        public double Altezza { get; set; }
        public double Cateto1 { get; set; }
        public double Cateto2 { get; set; }

        public Triangolo(double baseTriangolo, double altezza, double cateto1, double cateto2 )
        {
            Base = baseTriangolo;
            Altezza = altezza;
            Cateto1 = cateto1;
            Cateto2 = cateto2;
            IsQuadrilatero = false;
        }

        public override double CalcolaArea()
        {
            return Base * Altezza / 2;
        }

        public override double CalcolaPerimetro()
        {
            return Base + Cateto1 + Cateto2;
        }
        public override string ToString()
        {
            return $"Triangolo: base={Base} \tAltezza={Altezza} \tCateto1={Cateto1} \tCateto2={Cateto2}";
        }
        public override bool Equals(object obj)
        {
            Triangolo t = (Triangolo)obj;
            if (t == null)
            {
                return false;
            }
            return Base == t.Base && Altezza == t.Altezza && Cateto1 == t.Cateto1 && Cateto2 == t.Cateto2;
        }
    }
}
