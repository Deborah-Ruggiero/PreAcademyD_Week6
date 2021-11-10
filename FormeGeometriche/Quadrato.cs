using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche
{
    class Quadrato : Rettangolo
    {
        public Quadrato(double lato):base(lato, lato)
        {

        }
        public override string ToString()
        {
            return $"Quadrato: lato={Base}";
        }
    }
}
