using System;
using System.Collections.Generic;
using System.Text;

namespace VectorApp
{
    class Vector
    {
        double[] values;

        public int Length
        {
            get
            {
                return values.Length;
            }
        }

        public Vector(double[] values)
        {
            this.values = values;
        }

        public double dot(Vector vector)
        {
            if(vector.Length != this.Length)
            {
                throw new Exception("Длины векторов не совпадают");
            }
            double accum = 0;
            for(int i = 0; i < this.Length; i++)
            {
                accum += vector[i] * this[i];
            }
            return accum;
        }

        public Vector multiply(Vector vector)
        {
            if (vector.Length != this.Length)
            {
                throw new Exception("Длины векторов не совпадают");
            }
            double[] arr = new double[this.Length];
            for(int i = 0; i < this.Length; i++)
            {
                arr[i] = vector[i] * this[i];
            }
            return new Vector(arr);
        }

        public double this[int index]
        {
            get
            {
                return values[index];
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < this.Length; i++)
            {
                builder.Append($"{this[i]} ");
                if((i + 1) % 10 == 0)
                {
                    builder.Append('\n');
                }
            }
            return builder.ToString();
        }
    }
}
