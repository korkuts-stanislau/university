using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrewBondCalculator.DataTypes
{
    class Element
    {
        public Nod Nod1
        {
            get;
            set;
        }
        public Nod Nod2
        {
            get;
            set;
        }
        public Nod Nod3
        {
            get;
            set;
        }

        public double Tension
        {
            get;
            set;
        }


        public double Squre
        {
            get { return (1 * Nod2.X * Nod3.Y + Nod1.X * 1 * Nod2.Y + Nod1.Y * 1 * Nod3.X  - 1 * Nod2.Y * Nod3.X - Nod1.X * 1 * Nod3.Y - Nod1.Y * Nod2.X * 1) / 2; }
        }

        public Element(Nod nod1, Nod nod2, Nod nod3)
        {
            this.Nod1 = nod1;
            this.Nod2 = nod2;
            this.Nod3 = nod3;
            Tension = 0;
        }
    }
}
