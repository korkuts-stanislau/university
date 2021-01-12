using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrewBondCalculator.DataTypes
{
    class LocalRigidityMatrix
    {
        public double[,] matrix;
        public int[] location;
        public LocalRigidityMatrix(double[,] matrix, int first, int second, int third)
        {
            first = first * 2;
            second = second * 2;
            third = third * 2;
            this.matrix = matrix;
            location = new int[6] { first - 1, first, second - 1, second, third - 1, third };
        }
    }
}
