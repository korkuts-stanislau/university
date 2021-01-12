using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureLibrary
{
    public class Figure
    {
        public Figure(double x, double y, Brush brush)
        {
            X_center = x;
            Y_center = y;
            Brush = brush;
            IsSelected = false;
        }
        public double X_center { get; protected set; }
        public double Y_center { get; protected set; }
        public Brush Brush { get; set; }
        public bool IsSelected { get; set; }
        public virtual void Draw(PaintEventArgs e)
        {
            throw new Exception("Нельзя нарисовать абстрактную фигуру");
        }
        public virtual void Move(double x_shift, double y_shift)
        {
            X_center += x_shift;
            Y_center += y_shift;
        }
        public virtual bool IsPointIn(double x, double y)
        {
            throw new Exception("Нельзя проверить на вхождение точку в абстрактной фигуре");
        }
    }
}
