using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double x, double y, Brush brush, double w, double h) : base(x, y, brush)
        {
            Width = w;
            Height = h;
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brush, (float)(X_center - Width / 2), (float)(Y_center - Height / 2), (float)Width, (float)Height);
        }
        public override void Move(double x_shift, double y_shift)
        {
            base.Move(x_shift, y_shift);
        }
        public override bool IsPointIn(double x, double y)
        {
            if (X_center - Width / 2 <= x && x <= X_center + Width / 2 && Y_center - Height / 2 <= y && y <= Y_center + Height / 2)
                return true;
            return false;
        }
    }
}