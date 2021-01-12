using System;
using fl = FigureLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFigures
{
    public partial class AddFigure : Form
    {
        Figures main;
        double x, y;
        public AddFigure(Figures mainform, double x, double y)
        {
            main = mainform;
            this.x = x;
            this.y = y;
            InitializeComponent();
            InitializeColors();
            figureBox.Text = "Circle";
        }
        void InitializeColors()
        {
            Brush[] brushes = new Brush[] { Brushes.Black, Brushes.Blue, Brushes.Yellow, Brushes.Red, Brushes.Green, Brushes.White, Brushes.Gray, Brushes.Orange, Brushes.Purple, Brushes.Gold };
            Dictionary<Brush, string> comboSource = new Dictionary<Brush, string>();
            foreach (Brush brush in brushes)
            {
                string color = (string)brush.GetType().GetProperty("Color").GetValue(brush).GetType().GetProperty("Name").GetValue(brush.GetType().GetProperty("Color").GetValue(brush));
                comboSource.Add(brush, color);
            }
            colorBox.DataSource = new BindingSource(comboSource, null);
            colorBox.DisplayMember = "Value";
            colorBox.ValueMember = "Key";
        }
        private void figureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(figureBox.Text)
            {
                case "Circle":
                    radiusBox.ReadOnly = false;
                    verticesBox.ReadOnly = true;
                    heightBox.ReadOnly = true;
                    widthBox.ReadOnly = true;
                    break;
                case "Star":
                    radiusBox.ReadOnly = false;
                    verticesBox.ReadOnly = false;
                    heightBox.ReadOnly = true;
                    widthBox.ReadOnly = true;
                    break;
                case "Rectangle":
                    radiusBox.ReadOnly = true;
                    verticesBox.ReadOnly = true;
                    heightBox.ReadOnly = false;
                    widthBox.ReadOnly = false;
                    break;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                Brush brush = ((KeyValuePair<Brush, string>)colorBox.SelectedItem).Key;
                switch (figureBox.Text)
                {
                    case "Circle":
                        main.figures.Add(new fl.Circle(x, y, brush, double.Parse(radiusBox.Text)));
                        break;
                    case "Star":
                        main.figures.Add(new fl.Star(x, y, brush, double.Parse(radiusBox.Text), int.Parse(verticesBox.Text), Math.PI / 2));
                        break;
                    case "Rectangle":
                        main.figures.Add(new fl.Rectangle(x, y, brush, double.Parse(widthBox.Text), double.Parse(heightBox.Text)));
                        break;
                }
                main.panelInvalidate();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите верные данные");
            }
        }
    }
}
