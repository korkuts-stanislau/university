using System.Collections.Generic;

namespace FigureLib
{
    public class FigureComparer : IComparer<IFigure>
    {
        public int Compare(IFigure figure1, IFigure figure2)
        {
            if (figure1.Area > figure2.Area)
                return 1;
            else if (figure1.Area == figure2.Area)
                return 0;
            else
                return -1;
        }
    }
}
