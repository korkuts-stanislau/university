using System;

namespace FigureLib
{
    public class Circle : IFigure
    {
        public Circle(double x, double y, double r, string color)
        {
            if (r < 0)
                throw new Exception("Радиус не может быть меньше нуля");
            Center = new Point(x, y);
            radius = r;
            Color = color;
        }
        public Point Center { get; set; }
        double radius;
        public double Radius 
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Радиус не может быть меньше нуля");
                else
                    radius = value;
            }
        }
        public string Color { get; set; }
        public double Area 
        {
            get => Math.PI * Math.Pow(this.Radius, 2);
        }
        public double this[string option]
        {
            get
            {
                switch(option)
                {
                    case "x":
                        return this.Center.X;
                    case "y":
                        return this.Center.Y;
                    case "r":
                        return this.radius;
                    default:
                        throw new Exception("Неверный параметр индексатора");
                }
            }
        }
        public void Offset(double offsetX, double offsetY)
        {
            Center.X += offsetX;
            Center.Y += offsetY;
        }
        public override string ToString()
        {
            return $"Окружность. Центр({Center.X}, {Center.Y}), Радиус({radius}), Площадь({Math.Round(Area, 2)}), Цвет({Color}).";
        }
    }
}
