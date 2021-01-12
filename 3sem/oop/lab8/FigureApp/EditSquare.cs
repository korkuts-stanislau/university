using System;
using FigureLib;
using System.Windows.Forms;

namespace FigureApp
{
    public partial class EditSquare : Form
    {
        MainForm main;
        public EditSquare(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            InitializeForm();
        }
        void InitializeForm()
        {
            IFigure figure = main.figureBase[main.Figures_Grid.SelectedRows[0].Index];
            Coordinates.Text = $"{figure["x1"]},{figure["y1"]};{figure["x2"]},{figure["y2"]};{figure["x3"]},{figure["y3"]};{figure["x4"]},{figure["y4"]}";
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                main.figureBase[main.Figures_Grid.SelectedRows[0].Index].Offset(Convert.ToDouble(offsetX.Text), Convert.ToDouble(offsetY.Text));
                main.InitializeGrid();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите верные параметры");
            }
        }
    }
}
