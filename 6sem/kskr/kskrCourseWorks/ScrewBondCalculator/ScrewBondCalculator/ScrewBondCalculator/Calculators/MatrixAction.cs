using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrewBondCalculator.Calculators
{
      public static class MatrixAction
        {
            public static double[] MultipleMatVec(double[,] a, double[] b)
            {
                double[] c = new double[a.GetLength(0)];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int k = 0; k < a.GetLength(0); k++)
                        c[i] += a[i, k] * b[k];
                return c;
            }
            public static double[] MultipleVecConst(double[] a, double b)
            {
                double[] c = new double[a.GetLength(0)];
                for (int i = 0; i < a.GetLength(0); i++)
                    c[i] = a[i] * b;
                return c;
            }
            public static double[,] SubstrauctionMatMat(double[,] a, double[,] b)
            {
                double[,] c = new double[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(0); j++)
                        c[i, j] = a[i, j] - b[i, j];
                return c;
            }
            public static double[,] SubstrauctionMatVec(double[,] a, double[] b)
            {
                double[,] c = new double[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int k = 0; k < a.GetLength(0); k++)
                        c[i, k] -= a[i, k] - b[k];
                return c;
            }
            public static double[] SubstrauctionVecVec(double[] a, double[] b)
            {
                double[] c = new double[a.GetLength(0)];
                for (int i = 0; i < a.GetLength(0); i++)
                    c[i] = a[i] - b[i];
                return c;
            }
            public static double[,] AdditionMatMat(double[,] a, double[,] b)
            {
                double[,] c = new double[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(0); j++)
                        c[i, j] = a[i, j] + b[i, j];
                return c;
            }
            public static double[,] MultipleMatMat(double[,] a, double[,] b)
            {
                if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить.");
                double[,] r = new double[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            r[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return r;
            }
            public static double[,] MultipleMatConst(double[,] a, double b)
            {
                double[,] r = new double[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        r[i, j] = a[i, j] * b;
                    }
                }
                return r;
            }
            public static double[,] TransponMat(double[,] Matrix)
            {
                double[,] T = new double[Matrix.GetLength(1), Matrix.GetLength(0)];
                for (int i = 0; i < Matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < Matrix.GetLength(1); ++j)
                        T[j, i] = Matrix[i, j];
                }
                return T;
            }
        }
}
