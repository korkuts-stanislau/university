using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public interface IMatrix
    {
        public int Rows { get; }
        public int Columns { get; }
        public IMatrix Dot(IMatrix otherMatrix);
        public IMatrix Mul(IMatrix otherMatrix);
        public double this[int i, int j] { get; set; }
    }
}
