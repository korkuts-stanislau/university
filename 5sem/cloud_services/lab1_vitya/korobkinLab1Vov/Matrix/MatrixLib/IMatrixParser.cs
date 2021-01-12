using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLib
{
    public interface IMatrixParser
    {
        public IMatrix Parse(string text);
    }
}
