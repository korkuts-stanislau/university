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
using System.Reflection;

namespace WFigures
{
    public partial class Figures : Form
    {
        public List<fl.Figure> figures;
        public Figures()
        {
            InitializeComponent();
            figures = new List<fl.Figure>();
            StartInitialization();
            EditFigureEvent += EditFigure;
        }
        private void StartInitialization()
        {
            figures.Add(new fl.Circle(50, 50, Brushes.Green, 30));
            figures.Add(new fl.Star(100, 100, Brushes.Red, 30, 6, Math.PI / 2));
            figures.Add(new fl.Rectangle(150, 150, Brushes.Blue, 60, 60));
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            foreach(fl.Figure figure in figures)
            {
                figure.Draw(e);
            }
        }
        public void panelInvalidate()
        {
            panel.Invalidate();
        }
        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                foreach (fl.Figure figure in figures)
                {
                    figure.IsSelected = false;
                }
                figures.Reverse();
                foreach (fl.Figure figure in figures)
                {
                    if (figure.IsPointIn(e.X, e.Y))
                    {
                        figure.IsSelected = true;
                        break;
                    }
                }
                figures.Reverse();
            }
            else if (e.Button == MouseButtons.Right)
            {
                AddFigure form = new AddFigure(this, e.X, e.Y);
                form.Show();
            }
        }
        private void Figures_KeyDown(object sender, KeyEventArgs e)
        {
            fl.Figure selectedFigure = null;
            foreach(fl.Figure figure in figures)
            {
                if (figure.IsSelected)
                {
                    selectedFigure = figure;
                    break;
                }
            }
            if(selectedFigure != null)
            {
                switch (e.KeyData)
                {
                    case Keys.Right:
                        if(selectedFigure.X_center < panel.Width - 10)
                            selectedFigure.Move(10, 0);
                        break;
                    case Keys.Left:
                        if (selectedFigure.X_center > 10)
                            selectedFigure.Move(-10, 0);
                        break;
                    case Keys.Down:
                        if (selectedFigure.Y_center < panel.Height - 10)
                            selectedFigure.Move(0, 10);
                        break;
                    case Keys.Up:
                        if (selectedFigure.Y_center > 10)
                            selectedFigure.Move(0, -10);
                        break;
                }
                panelInvalidate();
            }
        }
        delegate void DoubleClickOnFigureHandler(object sender, ChangeFigureEventArgs e);
        event DoubleClickOnFigureHandler EditFigureEvent;
        void EditFigure(object sender, ChangeFigureEventArgs e)
        {
            figures.Remove(e.Figure);
            AddFigure form = new AddFigure(this, e.X, e.Y);
            form.Show();
            panelInvalidate();
        }
        private void panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fl.Figure figureToEdit = null;
            foreach (fl.Figure figure in figures)
            {
                if (figure.IsPointIn(e.X, e.Y))
                {
                    figureToEdit = figure;
                    break;
                }
            }
            if (figureToEdit != null)
            {
                EditFigureEvent.Invoke(sender, new ChangeFigureEventArgs(figureToEdit, e.X, e.Y));
            }
        }
        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
        fl.Figure prevSelected = null;
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            fl.Figure selected = null;
            foreach (fl.Figure figure in figures)
            {
                if (figure.IsPointIn(e.X, e.Y))
                {
                    selected = figure;
                    break;
                }
            }
            if(selected != null && !selected.Equals(prevSelected))
            {
                selected.Brush = PickBrush();
                prevSelected = selected;
                panelInvalidate();
            }
        }
    }
}
