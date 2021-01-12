using System;

namespace VectorLib
{
    public class Vector
    {
        double[] points;
        public Vector(params double[] points)
        {
            //if len of the array == 0 
            if(points.Length == 0)
                throw new Exception("Got an empty array");
            bool flag = true;
            foreach(double point in points)
            {
                if(Math.Abs(point) > 0.00001)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                throw new Exception("It is not a vector");
            this.points = points;
        }
        public double GetVectorLength()
        {
            double squared_sum = 0;
            foreach(double point in points)
            {
                squared_sum += point * point;
            }
            return Math.Sqrt(squared_sum);
        }
    }
}
