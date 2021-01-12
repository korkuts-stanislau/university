using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MatrixLib
{
    public class Matrix : IMatrix
    {
        private double[,] _values;

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _values = new double[rows, columns];
        }

        public Matrix(double[,] matrix)
        {
            _values = matrix;
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
        }

        public int Rows { get; }
        public int Columns { get; }

        //Скалярное произведение матриц
        public IMatrix Dot(IMatrix otherMatrix)
        {
            if (Columns != otherMatrix.Rows)
            {
                throw new Exception("Number of columns in the first matrix is not equal to number of rows of the second one.");
            }

            Matrix resultMatrix = new Matrix(Rows, otherMatrix.Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < otherMatrix.Columns; j++)
                {
                    double accumulation = 0;
                    for (int k = 0; k < Columns; k++)
                    {
                        accumulation += this[i, k] * otherMatrix[k, j];
                    }
                    resultMatrix[i, j] = accumulation;
                }
            }

            return resultMatrix;
        }

        //Векторное произведение матриц
        public IMatrix Mul(IMatrix otherMatrix)
        {
            if (Rows != otherMatrix.Rows)
            {
                throw new Exception("Number of rows in the first matrix is not equal to number of rows of the second one.");
            }

            if (Columns != otherMatrix.Columns)
            {
                throw new Exception("Number of columns in the first matrix is not equal to number of columns of the second one.");
            }

            Matrix resultMatrix = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultMatrix[i, j] = this[i, j] * otherMatrix[i, j];
                }
            }

            return resultMatrix;
        }

        public double this[int i, int j]
        {
            get => _values[i, j];
            set => _values[i, j] = value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    builder.Append(this[i, j] + " ");
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }
    }
}
