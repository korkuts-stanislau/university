using System;
using FigureLib;
using System.Windows.Forms;

namespace FigureApp
{
    public partial class EditCircle : Form
    {
        MainForm main;
        public EditCircle(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            InitializeForm();
        }
        void InitializeForm()
        {
            IFigure figure = main.figureBase[main.Figures_Grid.SelectedRows[0].Index];
            CircleInfo.Text = $"Центр ({figure["x"]}, {figure["y"]}), Радиус {figure["r"]}";
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
