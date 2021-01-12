using System;

namespace FigureLib
{
    public class Square : IFigure
    {
        public Square(double[] coords, string color)
        {
            if (IsSquare(coords[0], coords[1], coords[2], coords[3], coords[4], coords[5], coords[6], coords[7]))
            {
                coordinates = new Point[4];
                coordinates[0] = new Point(coords[0], coords[1]);
                coordinates[1] = new Point(coords[2], coords[3]);
                coordinates[2] = new Point(coords[4], coords[5]);
                coordinates[3] = new Point(coords[6], coords[7]);
                Color = color;
            }
            else
                throw new Exception("Такого квадрата не существует");
        }
        public string Color { get; set; }
        Point[] coordinates;
        private static bool IsSquare(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            if (x1 != x2 || y1 != y2)
                if (Math.Abs((x2 - x1)) == Math.Abs((y3 - y2)) && Math.Abs((y2 - y1)) == Math.Abs((x3 - x2)) && (x2 - x1 == 0 || y2 - y1 == 0))
                    if (Math.Abs((x4 - x1)) == Math.Abs((y4 - y3)) && Math.Abs((x4 - x3)) == Math.Abs((y4 - y1)) && (x4 - x1 == 0 || y4 - y1 == 0))
                        return true;
            return false;
        }
        public double Side
        {
            get => Math.Sqrt(Math.Pow(coordinates[0].X - coordinates[1].X, 2) + Math.Pow(coordinates[0].Y - coordinates[1].Y, 2));
        }
        public double Area
        {
            get => Math.Pow(Side, 2);
        }
        public double Perimeter
        {
            get => 4 * Side;
        }
        public double this[string option]
        {
            get
            {
                switch (option)
                {
                    case "x1": return coordinates[0].X;
                    case "y1": return coordinates[0].Y;
                    case "x2": return coordinates[1].X;
                    case "y2": return coordinates[1].Y;
                    case "x3": return coordinates[2].X;
                    case "y3": return coordinates[2].Y;
                    case "x4": return coordinates[3].X;
                    case "y4": return coordinates[3].Y;
                    case "s": return Area;
                    case "p": return Perimeter;
                }
                throw new Exception("Что-то пошло не так");
            }
        }
        public void Offset(double offsetX, double offsetY)
        {
            for(int i = 0; i < 4; i++)
            {
                coordinates[i].X += offsetX;
                coordinates[i].Y += offsetY;
            }
        }
        public override string ToString()
        {
            return $"Квадрат. Координаты точки({coordinates[0].X}, {coordinates[0].Y}), ({coordinates[1].X}, {coordinates[1].Y}), ({coordinates[2].X}, {coordinates[2].Y}), ({coordinates[3].X}, {coordinates[3].Y}).\n" +
                $"Площадь {Area}, Периметр {Perimeter}, Цвет {Color}.";
        }
    }
}
