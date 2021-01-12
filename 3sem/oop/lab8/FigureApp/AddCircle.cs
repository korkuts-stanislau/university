using System;
using FigureLib;
using System.Windows.Forms;

namespace FigureApp
{
    public partial class AddCircle : Form
    {
        MainForm main;
        public AddCircle(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Colors_Box.Equals(""))
                    throw new Exception("Не выбран цвет");
                main.figureBase.AddFigure(new Circle(Convert.ToDouble(Coord_X.Text), Convert.ToDouble(Coord_Y.Text),
                    Convert.ToDouble(Radius.Text), Colors_Box.Text));
                main.InitializeGrid();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введены неверные параметры");
            }
        }
    }
}
