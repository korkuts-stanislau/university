using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace MatrixLib
{
    public class MatrixParser : IMatrixParser
    {
        public IMatrix Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Invalid text to parse");
            }

            string[] rows = Regex.Split(text, "\\s*;\\s*");
            int rowsNum = rows.Length;

            int columnsNum = 0;
            foreach (var row in rows)
            {
                string[] rowValues = row.Split(' ');
                if (columnsNum == 0)
                {
                    columnsNum = rowValues.Length;
                }
                if (rowValues.Length != columnsNum)
                {
                    throw new Exception("This is not a matrix");
                }
            }

            Matrix matrix = new Matrix(rowsNum, columnsNum);

            int i = 0;
            foreach (var row in rows)
            {
                int j = 0;
                foreach (var value in Regex.Split(row, "\\s+"))
                {
                    if (double.TryParse(value, out double result))
                    {
                        matrix[i, j] = result;
                    }
                    else
                    {
                        throw new Exception("Problem with matrix parsing");
                    }
                    j++;
                }
                i++;
            }

            return matrix;
        }
    }
}
