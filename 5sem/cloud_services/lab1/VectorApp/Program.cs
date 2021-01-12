using System;

namespace VectorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = new double[] { 1, 2, 3, 4, 5 };
            double[] arr2 = new double[] { 1, 3, -11, 3, 1 };
            Vector vector1 = new Vector(arr1);
            Vector vector2 = new Vector(arr2);
            Console.WriteLine(vector1.dot(vector2));
            Console.WriteLine(vector2.multiply(vector1));
        }
    }
}
