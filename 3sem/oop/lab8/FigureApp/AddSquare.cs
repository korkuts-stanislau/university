using System;
using FigureLib;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FigureApp
{
    public partial class AddSquare : Form
    {
        MainForm main;
        public AddSquare(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Colors_Box.Text.Equals(""))
                    throw new Exception("");
                string[] coords = { x1.Text, y1.Text, x2.Text, y2.Text, x3.Text, y3.Text, x4.Text, y4.Text };
                main.figureBase.AddFigure(new Square(coords.Select(Double.Parse).ToArray(), Colors_Box.Text));
                main.InitializeGrid();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите верные значения");
            }

        }
    }
}
