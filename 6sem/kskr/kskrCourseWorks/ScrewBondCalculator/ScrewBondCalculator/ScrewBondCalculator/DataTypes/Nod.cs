using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrewBondCalculator.DataTypes
{
    class Nod
    {
        int number;
        double xLoad, yLoad, x, y, xDisplacement, yDisplacement;
        bool isConstraedByX, isConstraedByY;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double XLoad
        {
            get { return xLoad; }
            set { xLoad = value; }
        }
        public double YLoad
        {
            get { return yLoad; }
            set { yLoad = value; }
        }
        public double XDisplacement
        {
            get { return xDisplacement; }
            set { xDisplacement = value; }
        }
        public double YDisplacement
        {
            get { return yDisplacement; }
            set { yDisplacement = value; }
        }
        public bool IsConstraedByX
        {
            get { return isConstraedByX; }
            set { isConstraedByX = value; }
        }
        public bool IsConstraedByY
        {
            get { return isConstraedByY; }
            set { isConstraedByY = value; }
        }

        public Nod(int number, double x, double y, double xLoad, double yLoad)
        {
            this.number = number;
            this.x = x;
            this.y = y;
            this.xLoad = xLoad;
            this.yLoad = yLoad;
            isConstraedByX = false;
            isConstraedByY = false;
        }


        public double GetDistanceTo(Nod nod)
        {
            return Math.Sqrt(Math.Pow(this.x - nod.X, 2) + Math.Pow(this.y - nod.Y, 2));
        }

        public override string ToString()
        {
            return ("Номер узла: " + number + " X координата: " + x + " Y координата: " + y + " нагрузка по X: " + xLoad + " нагрузка по Y: " + yLoad + " перемещение по X: " + XDisplacement + " перемещение по Y: " + YDisplacement);
        }
    }
}
