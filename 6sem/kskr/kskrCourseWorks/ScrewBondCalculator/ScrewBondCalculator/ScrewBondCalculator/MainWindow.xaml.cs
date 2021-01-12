using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScrewBondCalculator.DataTypes;
using ScrewBondCalculator.Calculators;
using System.Globalization;

namespace ScrewBondCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool loadedVisible = false, freeVisible = false;
        static List<Line> loadedLines = new List<Line>();
        static List<Line> freeLines = new List<Line>();

        static double load, puasson, thikness, allowebleTension;
        static string[] nodesFormats, elementsFormats, constraintsFormat, loadsFormat;
        static List<Element> elements = new List<Element>();
        static List<Nod> nods = new List<Nod>();
        static Solver solver; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CollapseWindow(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenNodeFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                nodesFormats = File.ReadAllLines(openFileDialog.FileName);
        }

        private void OpenElementsFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                elementsFormats = File.ReadAllLines(openFileDialog.FileName);
        }

        private void OpenLoadsFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                loadsFormat = File.ReadAllLines(openFileDialog.FileName);
        }

        private void OpenConstraintsFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                constraintsFormat = File.ReadAllLines(openFileDialog.FileName);
        }

        private void Calculate(object sender, EventArgs e)
        {
            elements.Clear();
            nods.Clear();
            loadedLines.Clear();
            freeLines.Clear();
            drawField.Children.Clear();
            if (parse())
            {
                solver = new Solver(puasson, thikness, allowebleTension, elements, nods);
                neededCoilCountTB.Text = solver.Solve().ToString();
                drawFreeButton.IsEnabled = true;
                drawLoadedButton.IsEnabled = true;
                moveToRightButton.IsEnabled = true;
                moveToRightLeft.IsEnabled = true;
                moveToRightUp.IsEnabled = true;
                moveToRightDown.IsEnabled = true;
                maxScaleButton.IsEnabled = true;
                minScaleButton.IsEnabled = true;
            }
        }

        private void DrawFree(object sender, EventArgs e)
        {
            if (!freeVisible)
            {
                Line nextLine;
                foreach (Element el in elements)
                {
                    nextLine = new Line();
                    nextLine.X1 = el.Nod1.X * 8;
                    nextLine.Y1 = el.Nod1.Y * 8;
                    nextLine.X2 = el.Nod2.X * 8;
                    nextLine.Y2 = el.Nod2.Y * 8;
                    nextLine.Stroke = Brushes.White;
                    drawField.Children.Add(nextLine);
                    freeLines.Add(nextLine);


                    nextLine = new Line();
                    nextLine.X1 = el.Nod2.X * 8;
                    nextLine.Y1 = el.Nod2.Y * 8;
                    nextLine.X2 = el.Nod3.X * 8;
                    nextLine.Y2 = el.Nod3.Y * 8;
                    nextLine.Stroke = Brushes.White;
                    drawField.Children.Add(nextLine);
                    freeLines.Add(nextLine);

                    nextLine = new Line();
                    nextLine.X1 = el.Nod3.X * 8;
                    nextLine.Y1 = el.Nod3.Y * 8;
                    nextLine.X2 = el.Nod1.X * 8;
                    nextLine.Y2 = el.Nod1.Y * 8;
                    nextLine.Stroke = Brushes.White;
                    drawField.Children.Add(nextLine);
                    freeLines.Add(nextLine);
                }
            }
            else
            {
                foreach (Line l in freeLines)
                {
                    l.X1 = 0;
                    l.X2 = 0;
                    l.Y1 = 0;
                    l.Y2 = 0;
                }
            }
            freeVisible = !freeVisible;
        }

        private void DrawLoaded(object sender, EventArgs e)
        {
            if (!loadedVisible)
            {
                Line nextLine;
                foreach (Element el in elements)
                {
                    nextLine = new Line();
                    nextLine.X1 = (el.Nod1.X + el.Nod1.XDisplacement) * 8;
                    nextLine.Y1 = (el.Nod1.Y + el.Nod1.YDisplacement) * 8;
                    nextLine.X2 = (el.Nod2.X + el.Nod2.XDisplacement) * 8;
                    nextLine.Y2 = (el.Nod2.Y + el.Nod2.YDisplacement) * 8;
                    nextLine.Stroke = Brushes.LightGray;
                    drawField.Children.Add(nextLine);
                    loadedLines.Add(nextLine);

                    nextLine = new Line();
                    nextLine.X1 = (el.Nod2.X + el.Nod2.XDisplacement) * 8;
                    nextLine.Y1 = (el.Nod2.Y + el.Nod2.YDisplacement) * 8;
                    nextLine.X2 = (el.Nod3.X + el.Nod3.XDisplacement) * 8;
                    nextLine.Y2 = (el.Nod3.Y + el.Nod3.YDisplacement) * 8;
                    nextLine.Stroke = Brushes.LightGray;
                    drawField.Children.Add(nextLine);
                    loadedLines.Add(nextLine);

                    nextLine = new Line();
                    nextLine.X1 = (el.Nod3.X + el.Nod3.XDisplacement) * 8;
                    nextLine.Y1 = (el.Nod3.Y + el.Nod3.YDisplacement) * 8;
                    nextLine.X2 = (el.Nod1.X + el.Nod1.XDisplacement) * 8;
                    nextLine.Y2 = (el.Nod1.Y + el.Nod1.YDisplacement) * 8;
                    nextLine.Stroke = Brushes.LightGray;
                    drawField.Children.Add(nextLine);
                    loadedLines.Add(nextLine);
                }
            }
            else
            {
                foreach (Line l in loadedLines)
                {
                    l.X1 = 0;
                    l.X2 = 0;
                    l.Y1 = 0;
                    l.Y2 = 0;
                }
            }
            loadedVisible = !loadedVisible;
        }

        private void MoveToRight(object sender, EventArgs e)
        {
            Line nextLine;

            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.X1 += 10;
                    realLine.X2 += 10;
                }
            }
        }

        private void MoveToLeft(object sender, EventArgs e)
        {
            Line nextLine;

            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.X1 -= 10;
                    realLine.X2 -= 10;
                }
            }
        }

        private void MoveToUp(object sender, EventArgs e)
        {
            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.Y1 -= 10;
                    realLine.Y2 -= 10;
                }
            }
        }

        private void MoveToDown(object sender, EventArgs e)
        {
            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.Y1 += 10;
                    realLine.Y2 += 10;
                }
            }
        }

        private void MaxScale(object sender, EventArgs e)
        {
            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.Y1 *= 2;
                    realLine.Y2 *= 2;
                    realLine.X1 *= 2;
                    realLine.X2 *= 2;
                }
            }
        }

        private void MinScale(object sender, EventArgs e)
        {
            foreach (UIElement potencialLine in drawField.Children)
            {
                Line realLine;
                if (potencialLine is Line)
                {
                    realLine = potencialLine as Line;
                    realLine.Y1 /= 2;
                    realLine.Y2 /= 2;
                    realLine.X1 /= 2;
                    realLine.X2 /= 2;
                }
            }
        }

        private void NodsToFile(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Nods.txt");
            foreach (Nod n in nods)
            {
                sw.WriteLine(n);
            }
        }

        private void MoveWindowMouseDown(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }

        bool parse()
        {
            List<int> constraidNodsNumber = new List<int>();
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-GB");
            string[] devidedString;
            List<Nod> loadedNods = new List<Nod>();
            List<Tuple<Nod, Nod, double>> linkedLoadedNods = new List<Tuple<Nod, Nod, double>>();
            if (nodesFormats != null && elementsFormats != null && constraintsFormat != null && loadsFormat != null && Double.TryParse(loadsTB.Text, out load) && Double.TryParse(puassonTB.Text, out puasson) && Double.TryParse(thiknessTB.Text, out thikness) && Double.TryParse(thiknessTB.Text, out thikness) && Double.TryParse(allowebleTensionTB.Text, out allowebleTension))
            {
                //Ниже парсятся узлы которые нагруженылучаются, получаются их номера в конечноэлементной сетке
                List<int> numbersOfloadedNods = new List<int>(); //номера нагруженных узлов
                for (int i = 0, nod; i < loadsFormat.Length; i++)
                {
                    devidedString = loadsFormat[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (devidedString.Length == 5)
                    {
                        if (Int32.TryParse(devidedString[2].Trim(), out nod) && !numbersOfloadedNods.Contains<int>(nod))
                        {
                            numbersOfloadedNods.Add(nod);
                        }
                    }
                }

                //парсятся все узлы
                int number;
                double x, y;
                foreach (string str1 in nodesFormats)
                {
                    devidedString = str1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (devidedString.Length == 7)
                    {
                        if (Int32.TryParse(devidedString[0].Trim(), style, culture, out number) && Double.TryParse(devidedString[1].Trim(), style, culture, out x) && Double.TryParse(devidedString[2].Trim(), style, culture, out y))
                        {
                            nods.Add(new Nod(number, x, y, 0, 0));
                            if (numbersOfloadedNods.Contains(number))//если узел нагружен, добавить его в список нагруженных узлов
                            {
                                loadedNods.Add(nods.Last());
                            }
                        }
                    }
                }

                //ниже находятся все узлы, к которым прикладываются силы и они группируются попарно
                double minDistance, currentDistance;
                for (int i1 = 0; i1 < loadedNods.Count - 1; i1++)
                {
                    //тут короче все сложно, не забивай голову. Вобщем находятся пары близлежащих узлов, критерием их поиска
                    //является расстояние,  для каждого узла находится минимальное расстояние до другого узла, после эти два 
                    //узла запоминаются 
                    minDistance = double.MaxValue;
                    linkedLoadedNods.Add(new Tuple<Nod, Nod, double>(loadedNods[i1], loadedNods[i1], 0));
                    for (int i2 = i1 + 1; i2 < loadedNods.Count; i2++)
                    {
                        currentDistance = loadedNods[i1].GetDistanceTo(loadedNods[i2]);
                        if (minDistance > currentDistance)
                        {
                            minDistance = currentDistance;
                            linkedLoadedNods[i1] = new Tuple<Nod, Nod, double>(loadedNods[i1], loadedNods[i2], currentDistance);
                        }
                    }
                }

                //добавдение нагрузок всем узлам, так как у меня нагрузка только по X нагружаю соответственно только X
                double totalSummLengthOfLoadedLine = 0;
                Nod someNode1, someNode2;
                foreach (Tuple<Nod, Nod, double> s in linkedLoadedNods)
                {
                    totalSummLengthOfLoadedLine += s.Item3;
                }
                foreach (Tuple<Nod, Nod, double> s in linkedLoadedNods)
                {
                    someNode1 = s.Item1;
                    someNode2 = s.Item2;
                    someNode1.XLoad += (s.Item3 / totalSummLengthOfLoadedLine / 2) * load;
                    someNode2.XLoad += (s.Item3 / totalSummLengthOfLoadedLine / 2) * load;
                }

                int nodeNumber;
                foreach (string str2 in constraintsFormat)
                {
                    devidedString = str2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (devidedString.Length == 4 && Int32.TryParse(devidedString[0], out nodeNumber))
                    {
                        if (devidedString[1] == "UY")
                        {
                            nods.Where(n => n.Number == nodeNumber).ToArray()[0].IsConstraedByY = true;
                            constraidNodsNumber.Add(nodeNumber);
                        }
                        else if (devidedString[1] == "UX")
                        {
                            nods.Where(n => n.Number == nodeNumber).ToArray()[0].IsConstraedByX = true;
                            constraidNodsNumber.Add(nodeNumber);
                        }
                    }
                }

                int firstNodeNumber, secondNodeNumber, thridNodeNumber;
                Nod firstNode, secondNode, thridNode;
                foreach (string str3 in elementsFormats)
                {
                    devidedString = str3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (devidedString.Length == 10 &&
                        Int32.TryParse(devidedString[6], out firstNodeNumber) &&
                        Int32.TryParse(devidedString[7], out secondNodeNumber) &&
                        Int32.TryParse(devidedString[8], out thridNodeNumber))
                    {
                        firstNode = nods.Where(n => n.Number == firstNodeNumber).ToArray()[0];
                        secondNode = nods.Where(n => n.Number == secondNodeNumber).ToArray()[0];
                        thridNode = nods.Where(n => n.Number == thridNodeNumber).ToArray()[0];
                        elements.Add(new Element(firstNode, secondNode, thridNode));
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Не загружены данные для рассчета либо они инвалидны.");
                return false;
            }
                
        }
    }
}
