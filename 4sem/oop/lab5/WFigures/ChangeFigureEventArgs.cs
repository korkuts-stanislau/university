using System;
using fl = FigureLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFigures
{
    class ChangeFigureEventArgs
    {
        public fl.Figure Figure { get; }
        public double X { get; }
        public double Y { get; }
        public ChangeFigureEventArgs(fl.Figure figure, double x, double y)
        {
            Figure = figure;
            X = x;
            Y = y;
        }
    }
}
