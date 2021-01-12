using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FigureLib
{
    public class FigureBase
    {
        IFigure[] figures;
        public FigureBase(string path)
        {
            ReadFiguresFromFile(path);
        }
        private void ReadFiguresFromFile(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                List<IFigure> figuresList = new List<IFigure>();
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    figuresList.Add(FromStringToFigure(line));
                }
                figures = figuresList.ToArray();
            }
        }
        private IFigure FromStringToFigure(string figureString)
        {
            string[] data = figureString.Split(' ');
            if (data.Length == 4)
            {
                return new Circle(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]), Convert.ToDouble(data[2]), data[3]);
            }
            else if (data.Length == 9)
            {
                return new Square(new ArraySegment<string>(data, 0, 8).Select(double.Parse).ToArray(), data[8]);
            }
            else
                throw new Exception("Неверный формат строки");
        }
        public void Sort()
        {
            Array.Sort(figures, new FigureComparer());
        }
        public IFigure this[int index]
        {
            get => figures[index];
            set => figures[index] = value;
        }
        public int Length { get => figures.Length; }
        public void DeleteFigure(int index)
        {
            IFigure[] newFigures = new IFigure[Length - 1];
            int j = 0;
            for(int i = 0; i < Length; i++)
            {
                if(i != index)
                {
                    newFigures[j] = figures[i];
                    j += 1;
                }
            }
            figures = newFigures;
        }
        public void AddFigure(IFigure figure)
        {
            IFigure[] newFigures = new IFigure[Length + 1];
            for (int i = 0; i < Length; i++)
                    newFigures[i] = figures[i];
            newFigures[Length] = figure;
            figures = newFigures;
        }
    }
}
