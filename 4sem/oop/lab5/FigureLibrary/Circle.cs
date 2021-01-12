using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(double x, double y, Brush brush, double radius) : base(x, y, brush)
        {
            Radius = radius;
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brush, (float)(X_center - Radius), (float)(Y_center - Radius), (float)(Radius * 2), (float)(Radius * 2));
        }
        public override void Move(double x_shift, double y_shift)
        {
            base.Move(x_shift, y_shift);
        }
        public override bool IsPointIn(double x, double y)
        {
            if (Math.Pow(x - X_center, 2) + Math.Pow(y - Y_center, 2) <= Math.Pow(Radius, 2))
                return true;
            return false;
        }
    }
}
