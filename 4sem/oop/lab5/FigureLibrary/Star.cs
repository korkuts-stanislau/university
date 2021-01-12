using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Star : Circle
    {
        public int VerticesNumber { get; }
        public double Angle { get; }
        public PointF[] Points { get; private set; }
        public Star(double x, double y, Brush brush, double radius, int verticesNumber, double angle) : base(x, y, brush, radius)
        {
            VerticesNumber = verticesNumber;
            Angle = angle;
            InitializePoints();
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(Brush, Points);
        }
        public override void Move(double x_shift, double y_shift)
        {
            base.Move(x_shift, y_shift);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].X += (float)x_shift;
                Points[i].Y += (float)y_shift;
            }
        }
        private void InitializePoints()
        {
            Points = new PointF[2 * VerticesNumber + 1];
            double a = Angle, da = Math.PI / VerticesNumber, r = Radius / 2, l;
            for(int k = 0; k < 2 * VerticesNumber + 1; k++)
            {
                l = k % 2 == 0 ? r : Radius;
                Points[k] = new PointF((float)(X_center + l * Math.Cos(a)), (float)(Y_center + l * Math.Sin(a)));
                a += da;
            }
        }
    }
}
