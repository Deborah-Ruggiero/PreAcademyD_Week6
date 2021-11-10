using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    abstract class Forma : IForma
    {
        public bool IsQuadrilatero { get; set; }
        abstract public double CalcolaArea();

        abstract public double CalcolaPerimetro();

    }
}
