using System;
using FigureLib;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FigureApp
{
    public partial class MainForm : Form
    {
        public FigureBase figureBase;
        public MainForm()
        {
            InitializeComponent();
            try 
            { 
                figureBase = new FigureBase(@"C:\korkuts_itp-21_oop\lab8\Figures.txt");
                InitializeGrid();
            }
            catch { MessageBox.Show("Файл содержит неверные строки"); }
        }

        public void InitializeGrid()
        {
            Figures_Grid.Rows.Clear();
            for(int i = 0; i < figureBase.Length; i++)
            {
                if(figureBase[i] is Circle)
                {
                    Figures_Grid.Rows.Add(figureBase[i].ToString());
                    Figures_Grid.Rows[i].DefaultCellStyle.ForeColor = Color.FromName(figureBase[i].Color);
                }
                else
                {
                    Figures_Grid.Rows.Add(figureBase[i].ToString());
                }
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Хотите ли вы добавить окружность?", "Добавить", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes )
            {
                AddCircle add = new AddCircle(this);
                add.Show();
            }
            else if(result == DialogResult.No)
            {
                AddSquare add = new AddSquare(this);
                add.Show();
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Figures_Grid.SelectedRows[0].Cells[0].Value.ToString().Contains("Окружность"))
                {
                    EditCircle edit = new EditCircle(this);
                    edit.Show();
                }
                else
                {
                    EditSquare edit = new EditSquare(this);
                    edit.Show();
                }
            }
            catch
            {
                MessageBox.Show("Выберите фигуру для изменения");
            }
        }

        private void Sort_Button_Click(object sender, EventArgs e)
        {
            figureBase.Sort();
            InitializeGrid();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try 
            { 
                figureBase.DeleteFigure(Figures_Grid.SelectedRows[0].Index);
                InitializeGrid();
            }
            catch { MessageBox.Show("Выберите элемент для удаления"); }
        }

        private void CalcSquarePerimeters_Click(object sender, EventArgs e)
        {
            List<double> perimeters = new List<double>();
            for (int i = 0; i < figureBase.Length; i++)
            {
                if ((figureBase[i] is Square) && (figureBase[i].Color == "Red"))
                {
                    perimeters.Add(figureBase[i]["p"]);
                }
            }
            StringBuilder p = new StringBuilder();
            int count = 1;
            foreach (double perimeter in perimeters)
            {
                p.Append($"Периметр {count} квадрата = {perimeter}.\n");
                count += 1;
            }
            MessageBox.Show(p.ToString(), "Периметры красных квадратов");
        }
    }
}
