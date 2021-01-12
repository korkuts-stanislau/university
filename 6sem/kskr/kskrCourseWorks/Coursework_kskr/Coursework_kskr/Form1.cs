using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Coursework_kskr
{
    public partial class Form1 : Form
    {
        float scale = 5000, maxStress;
        List<Node> node;
        List<Element> element;
        int[] fixingNodes = new int[] { 14, 15, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86 };
        float[,] globalK;
        Graphics graphic;
        SolidBrush solidBrush1, solidBrush2, solidBrush3, solidBrush4, solidBrush5, solidBrush6, solidBrush7, solidBrush8, solidBrush9;
        bool edit = false;

        public Form1()
        {
            InitializeComponent();
            graphic = panel.CreateGraphics();
            solidBrush1 = new SolidBrush(Color.Blue);
            solidBrush2 = new SolidBrush(Color.DarkTurquoise);
            solidBrush3 = new SolidBrush(Color.LightSkyBlue);
            solidBrush4 = new SolidBrush(Color.Aqua);
            solidBrush5 = new SolidBrush(Color.LimeGreen);
            solidBrush6 = new SolidBrush(Color.GreenYellow);
            solidBrush7 = new SolidBrush(Color.Yellow);
            solidBrush8 = new SolidBrush(Color.Orange);
            solidBrush9 = new SolidBrush(Color.Red);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            node = InputDate.Nodes();
            element = InputDate.Elements(node);
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);

            if (edit)
            {
                graphic.TranslateTransform(-(panel.Width - Convert.ToSingle(textBoxLength.Text) * scale) / 2, -(350 - (panel.Height - Convert.ToSingle(textBoxLength.Text) / 2 * scale) / 2));
            }
            edit = true;
            graphic.TranslateTransform((panel.Width - Convert.ToSingle(textBoxLength.Text) * scale) / 2, (350 - (panel.Height - Convert.ToSingle(textBoxLength.Text) / 2 * scale) / 2));

            graphic.Clear(Color.White);
            Meshing(Color.Black);

            radioButtonDeformation.Enabled = false;
            radioButtonDeformationX.Enabled = false;
            radioButtonDeformationY.Enabled = false;
            radioButtonStress.Enabled = false;
            buttonSolve.Enabled = true;

            Pen p1 = new Pen(Color.Blue, 3);
            graphic.DrawLine(p1, node[0].X * scale, -node[0].Y * scale, node[1].X * scale, -node[1].Y * scale);
            graphic.DrawLine(p1, node[0].X * scale, -node[0].Y * scale, node[108].X * scale, -node[108].Y * scale);
            graphic.DrawLine(p1, 0, 40, 50, 40);
            graphic.DrawString("Закрепление", new Font("Times new Roman", 10), Brushes.Black, 70, 35);

            Pen p2 = new Pen(Color.Red, 3);
            p2.EndCap = LineCap.ArrowAnchor;
            graphic.DrawLine(p2, node[fixingNodes[7]].X * scale, 0, node[fixingNodes[7]].X * scale, 0);
            for (int i = 0; i < fixingNodes.Length; i++)
            {
                graphic.DrawLine(p2, node[fixingNodes[i]].X * scale + 5, -node[fixingNodes[i]].Y * scale, node[fixingNodes[i]].X * scale + 50, -node[fixingNodes[i]].Y * scale);
            }
            graphic.DrawLine(p2, 0, 20, 50, 20);
            graphic.DrawString("Нагрузка", new Font("Times new Roman", 10), Brushes.Black, 70, 15);
        }

        /// <summary>
        /// Отрисовк сетки.
        /// </summary>
        /// <param name="color">установка цвета</param>
        void Meshing(Color color)
        {
            Pen p = new Pen(color);
            for (int i = 0; i < element.Count; i++)
            {
                graphic.DrawLine(p, element[i].Node1.X * scale, -element[i].Node1.Y * scale, element[i].Node2.X * scale, -element[i].Node2.Y * scale);
                graphic.DrawLine(p, element[i].Node2.X * scale, -element[i].Node2.Y * scale, element[i].Node3.X * scale, -element[i].Node3.Y * scale);
                graphic.DrawLine(p, element[i].Node3.X * scale, -element[i].Node3.Y * scale, element[i].Node1.X * scale, -element[i].Node1.Y * scale);
            }
        }

        /// <summary>
        /// Решение.
        /// </summary>
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);

            // Создание матрицы элементов.
            for (int i = 0; i < element.Count; i++)
            {
                element[i].CreateMatrix(Convert.ToSingle(textBoxThickness.Text), Convert.ToSingle(textBoxElasticModulus.Text), Convert.ToSingle(textBoxPoissonsRatio.Text));
            }

            // Вычисляем локальную матрицу жёсткости.
            globalK = new float[node.Count * 2, node.Count * 2 + 1];
            int[] listIndex = new int[3];
            for (int i = 0; i < element.Count; i++)
            {
                listIndex[0] = element[i].Node1.Index;
                listIndex[1] = element[i].Node2.Index;
                listIndex[2] = element[i].Node3.Index;
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        globalK[2 * listIndex[j], 2 * listIndex[k]] = globalK[2 * listIndex[j], 2 * listIndex[k]] + element[i].K[j * 2, k * 2];
                        globalK[2 * listIndex[j] + 1, 2 * listIndex[k]] = globalK[2 * listIndex[j] + 1, 2 * listIndex[k]] + element[i].K[j * 2 + 1, k * 2];
                        globalK[2 * listIndex[j], 2 * listIndex[k] + 1] = globalK[2 * listIndex[j], 2 * listIndex[k] + 1] + element[i].K[j * 2, k * 2 + 1];
                        globalK[2 * listIndex[j] + 1, 2 * listIndex[k] + 1] = globalK[2 * listIndex[j] + 1, 2 * listIndex[k] + 1] + element[i].K[j * 2 + 1, k * 2 + 1];
                    }
            }

            // Вычисляем глобальную матрицу жёсткости.
            for (int i = 0; i < fixingNodes.Length; i++)
            {
                globalK[fixingNodes[i] * 2, node.Count * 2] = Convert.ToSingle(textBoxForce.Text);
            }

            for (int i = 0; i < node.Count; i++)
            {
                if (node[i].Fixation)
                {
                    for (int j = 0; j < node.Count * 2; j++)
                    {
                        globalK[2 * i, j] = 0;
                        globalK[2 * i + 1, j] = 0;
                        globalK[j, 2 * i] = 0;
                        globalK[j, 2 * i + 1] = 0;
                    }
                    globalK[2 * i, 2 * i] = 1;
                    globalK[2 * i + 1, 2 * i + 1] = 1;
                }
            }

            // Решение СЛАУ методом Гаусса.
            globalK = Matrix.Gaus(node, globalK);
            for (int i = 0; i < element.Count; i++)
            {
                element[i].Sig[0, 0] = globalK[2 * element[i].Node1.Index, 2 * node.Count];
                element[i].Sig[1, 0] = globalK[2 * element[i].Node1.Index + 1, 2 * node.Count];
                element[i].Sig[2, 0] = globalK[2 * element[i].Node2.Index, 2 * node.Count];
                element[i].Sig[3, 0] = globalK[2 * element[i].Node2.Index + 1, 2 * node.Count];
                element[i].Sig[4, 0] = globalK[2 * element[i].Node3.Index, 2 * node.Count];
                element[i].Sig[5, 0] = globalK[2 * element[i].Node3.Index + 1, 2 * node.Count];
            }

            for (int i = 0; i < element.Count; i++)
            {
                element[i].SolveStress();
            }

            MaxDeformationXAndY();

            labelStresOk.Text = maxStress > int.MaxValue ? "нет" : "да";
        }

        // Определение максимальных смещений и напряжения.
        void MaxDeformationXAndY()
        {
            float maxX = globalK[0, 2 * node.Count];
            float maxY = globalK[0, 2 * node.Count];

            for (int i = 0; i < node.Count; i++)
            {
                if (globalK[i * 2, 2 * node.Count] > maxX) maxX = globalK[i * 2, 2 * node.Count];
                if (globalK[i * 2 + 1, 2 * node.Count] > maxY) maxY = globalK[i * 2 + 1, 2 * node.Count];
            }

            maxStress = element[0].S;
            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].S > maxStress) maxStress = element[i].S;
            }

            labelMaxDeformationX.Text = maxX.ToString();
            labelMaxDeformationY.Text = maxY.ToString();
            labelStress.Text = maxStress.ToString();
            radioButtonDeformation.Enabled = true;
            radioButtonDeformationX.Enabled = true;
            radioButtonDeformationY.Enabled = true;
            radioButtonStress.Enabled = true;

            graphic.Clear(Color.White);
            Meshing(Color.Black);
        }

        /// <summary>
        /// Отрисовка деформированной детали.
        /// </summary>
        private void radioButtonDeformation_CheckedChanged(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            Pen p = new Pen(Color.Black, 1);
            for (int i = 0; i < element.Count; i++)
            {
                graphic.DrawLine(p, (element[i].Node1.X + element[i].Sig[0, 0] * 200f) * scale, -(element[i].Node1.Y + element[i].Sig[1, 0] * 200f) * scale, (element[i].Node2.X + element[i].Sig[2, 0] * 200f) * scale, -(element[i].Node2.Y + element[i].Sig[3, 0] * 200f) * scale);
                graphic.DrawLine(p, (element[i].Node2.X + element[i].Sig[2, 0] * 200f) * scale, -(element[i].Node2.Y + element[i].Sig[3, 0] * 200f) * scale, (element[i].Node3.X + element[i].Sig[4, 0] * 200f) * scale, -(element[i].Node3.Y + element[i].Sig[5, 0] * 200f) * scale);
                graphic.DrawLine(p, (element[i].Node3.X + element[i].Sig[4, 0] * 200f) * scale, -(element[i].Node3.Y + element[i].Sig[5, 0] * 200f) * scale, (element[i].Node1.X + element[i].Sig[0, 0] * 200f) * scale, -(element[i].Node1.Y + element[i].Sig[1, 0] * 200f) * scale);
            }
        }

        /// <summary>
        /// Отрисовка смещения по оси Х.
        /// </summary>
        private void radioButtonDeformationX_CheckedChanged(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            float[] maxmin = new float[element.Count];

            for (int i = 0; i < element.Count; i++)
            {
                maxmin[i] = Math.Abs(globalK[2 * element[i].Node1.Index, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node2.Index, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node3.Index, 2 * node.Count]);
            }

            float maxX = maxmin[0];
            float minX = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxX) maxX = maxmin[i];
                if (maxmin[i] < minX) minX = maxmin[i];
            }

            float dX = (maxX - minX) / 9;

            for (int i = 0; i < element.Count; i++)
            {
                float sumX = Math.Abs(globalK[2 * element[i].Node1.Index, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node2.Index, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node3.Index, 2 * node.Count]);
                if (sumX >= minX && sumX < minX + dX) element[i].ColorElement = solidBrush1;
                else if (sumX >= minX + dX && sumX < minX + 2 * dX) element[i].ColorElement = solidBrush2;
                else if (sumX >= minX + 2 * dX && sumX < minX + 3 * dX) element[i].ColorElement = solidBrush3;
                else if (sumX >= minX + 3 * dX && sumX < minX + 4 * dX) element[i].ColorElement = solidBrush4;
                else if (sumX >= minX + 4 * dX && sumX < minX + 5 * dX) element[i].ColorElement = solidBrush5;
                else if (sumX >= minX + 5 * dX && sumX < minX + 6 * dX) element[i].ColorElement = solidBrush6;
                else if (sumX >= minX + 6 * dX && sumX < minX + 7 * dX) element[i].ColorElement = solidBrush7;
                else if (sumX >= minX + 7 * dX && sumX < minX + 8 * dX) element[i].ColorElement = solidBrush8;
                else if (sumX >= minX + 8 * dX && sumX <= maxX) element[i].ColorElement = solidBrush9;
            }

            DrawingDeformation();
        }

        /// <summary>
        /// Отрисовка смещения по оси Y.
        /// </summary>
        private void radioButtonDeformationY_CheckedChanged(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            float[] maxmin = new float[element.Count];
            for (int i = 0; i < element.Count; i++)
            {
                maxmin[i] = Math.Abs(globalK[2 * element[i].Node1.Index + 1, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node2.Index + 1, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node3.Index + 1, 2 * node.Count]);
            }

            float maxY = maxmin[0];
            float minY = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxY) maxY = maxmin[i];
                if (maxmin[i] < minY) minY = maxmin[i];
            }

            float dX = (maxY - minY) / 9;

            for (int i = 0; i < element.Count; i++)
            {
                float sumY = Math.Abs(globalK[2 * element[i].Node1.Index + 1, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node2.Index + 1, 2 * node.Count]) + Math.Abs(globalK[2 * element[i].Node3.Index + 1, 2 * node.Count]);
                if (sumY >= minY && sumY < minY + dX) element[i].ColorElement = solidBrush1;
                else if (sumY >= minY + dX && sumY < minY + 2 * dX) element[i].ColorElement = solidBrush2;
                else if (sumY >= minY + 2 * dX && sumY < minY + 3 * dX) element[i].ColorElement = solidBrush3;
                else if (sumY >= minY + 3 * dX && sumY < minY + 4 * dX) element[i].ColorElement = solidBrush4;
                else if (sumY >= minY + 4 * dX && sumY < minY + 5 * dX) element[i].ColorElement = solidBrush5;
                else if (sumY >= minY + 5 * dX && sumY < minY + 6 * dX) element[i].ColorElement = solidBrush6;
                else if (sumY >= minY + 6 * dX && sumY < minY + 7 * dX) element[i].ColorElement = solidBrush7;
                else if (sumY >= minY + 7 * dX && sumY < minY + 8 * dX) element[i].ColorElement = solidBrush8;
                else if (sumY >= minY + 8 * dX && sumY <= maxY) element[i].ColorElement = solidBrush9;
            }

            DrawingDeformation();
        }

        /// <summary>
        /// Отрисовка напряжений.
        /// </summary>
        private void radioButtonStress_CheckedChanged(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            float[] maxmin = new float[element.Count];
            for (int i = 0; i < element.Count; i++)
            {
                maxmin[i] = element[i].S;
            }

            float maxS = maxmin[0];
            float minS = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxS) maxS = maxmin[i];
                if (maxmin[i] < minS) minS = maxmin[i];
            }

            float dX = (maxS - minS) / 9;

            for (int i = 0; i < element.Count; i++)
            {
                float sumD = element[i].S;
                if (sumD >= minS && sumD < minS + dX) element[i].ColorElement = solidBrush1;
                else if (sumD >= minS + dX && sumD < minS + 2 * dX) element[i].ColorElement = solidBrush2;
                else if (sumD >= minS + 2 * dX && sumD < minS + 3 * dX) element[i].ColorElement = solidBrush3;
                else if (sumD >= minS + 3 * dX && sumD < minS + 4 * dX) element[i].ColorElement = solidBrush4;
                else if (sumD >= minS + 4 * dX && sumD < minS + 5 * dX) element[i].ColorElement = solidBrush5;
                else if (sumD >= minS + 5 * dX && sumD < minS + 6 * dX) element[i].ColorElement = solidBrush6;
                else if (sumD >= minS + 6 * dX && sumD < minS + 7 * dX) element[i].ColorElement = solidBrush7;
                else if (sumD >= minS + 7 * dX && sumD < minS + 8 * dX) element[i].ColorElement = solidBrush8;
                else if (sumD >= minS + 8 * dX && sumD <= maxS) element[i].ColorElement = solidBrush9;
            }

            DrawingDeformation();
        }

        /// <summary>
        /// Отрисовка цветов.
        /// </summary>
        private void DrawingDeformation()
        {
            for (int i = 0; i < element.Count; i++)
            {
                Point[] points = new Point[3];
                points[0] = new Point(Convert.ToInt32((element[i].Node1.X + element[i].Sig[0, 0] * 200f) * scale), -Convert.ToInt32((element[i].Node1.Y + element[i].Sig[1, 0] * 200f) * scale));
                points[1] = new Point(Convert.ToInt32((element[i].Node2.X + element[i].Sig[2, 0] * 200f) * scale), -Convert.ToInt32((element[i].Node2.Y + element[i].Sig[3, 0] * 200f) * scale));
                points[2] = new Point(Convert.ToInt32((element[i].Node3.X + element[i].Sig[4, 0] * 200f) * scale), -Convert.ToInt32((element[i].Node3.Y + element[i].Sig[5, 0] * 200f) * scale));

                graphic.FillPolygon(element[i].ColorElement, points);

                Pen p = new Pen(Color.Black, 1);
                graphic.DrawLine(p, (element[i].Node1.X + element[i].Sig[0, 0] * 200f) * scale, -(element[i].Node1.Y + element[i].Sig[1, 0] * 200f) * scale, (element[i].Node2.X + element[i].Sig[2, 0] * 200f) * scale, -(element[i].Node2.Y + element[i].Sig[3, 0] * 200f) * scale);
                graphic.DrawLine(p, (element[i].Node2.X + element[i].Sig[2, 0] * 200f) * scale, -(element[i].Node2.Y + element[i].Sig[3, 0] * 200f) * scale, (element[i].Node3.X + element[i].Sig[4, 0] * 200f) * scale, -(element[i].Node3.Y + element[i].Sig[5, 0] * 200f) * scale);
                graphic.DrawLine(p, (element[i].Node3.X + element[i].Sig[4, 0] * 200f) * scale, -(element[i].Node3.Y + element[i].Sig[5, 0] * 200f) * scale, (element[i].Node1.X + element[i].Sig[0, 0] * 200f) * scale, -(element[i].Node1.Y + element[i].Sig[1, 0] * 200f) * scale);
            }
        }

    }
}