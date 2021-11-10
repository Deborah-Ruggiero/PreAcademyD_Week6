using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Cerchio : Forma
    {
        public double Raggio { get; set; }
        //private const double pi = 3.14;

        public Cerchio(double raggio)
        {
            Raggio = raggio;
            IsQuadrilatero = false;
        }
        public override double CalcolaArea()
        {
            return Math.Pow(Raggio,2) * Math.PI;
        }

        public override double CalcolaPerimetro()
        {
            return 2 * Raggio * Math.PI;
        }

        public override string ToString()
        {
            return $"Cerchio: Raggio={Raggio}";
        }
        public override bool Equals(object obj)
        {
            Cerchio c = (Cerchio)obj;
            if (c == null)
            {
                return false;
            }
            return Raggio == c.Raggio;
        }
    }
}
