using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MachineLearn
{
    public partial class Form2 : Form
    {
        int details, shifts;
        List<Operation> operations = new List<Operation>();

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label10.Text = Convert.ToString(trackBar1.Value);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(details);
            label3.Text = Convert.ToString(shifts);
            label12.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox3.Text;
                int details = Convert.ToInt32(label2.Text);
                int shifts = Convert.ToInt32(label3.Text);
                double time = Convert.ToDouble(textBox2.Text);
                int coef = Convert.ToInt32(label10.Text);
                textBox1.Text += String.Format("{0}, Время выполнения {1} минут, Коеффициент нагрузки {2}" + Environment.NewLine, name, time, coef);
                operations.Add(new Operation(name, details, shifts, time, coef));
                label6.Text = calculateModeOfProduction();
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch
            {
                label12.Text = "Вы ввели неправильные данные";
            }
        }
        string calculateModeOfProduction()
        {
            double kzo = 0;
            int sumOpr = 0, sumP = 0;
            foreach(Operation operation in operations)
            {
                int[] values = calculateOprAndP((double)operation.details, (double)operation.shifts, (double)operation.time, (double)operation.coef);
                sumOpr += values[0];
                sumP += values[1];
            }
            kzo = sumOpr / sumP;
            if(kzo < 1)
            {
                return "Массовое производство";
            }
            if (kzo < 10)
            {
                return "Крупносерийное производство";
            }
            if (kzo < 20)
            {
                return "Среднесерийное производство";
            }
            if (kzo < 40)
            {
                return "Мелкосерийное производство";
            }
            else
            {
                return "Единичное производство";
            }
        }
        int[] calculateOprAndP(double details, double shifts, double time, double coef)
        {
            double fd = 8 * shifts * 250;
            double mp = (details * time) / (60 * fd * (coef / 100));
            double p = Math.Ceiling(mp);
            double nf = mp / p;
            double o = coef / 100 / nf;
            double opr;
            if(o < 1)
                opr = 1;
            else
                opr = Math.Floor(o);
            int[] ret_ar = new int[] { Convert.ToInt32(opr), Convert.ToInt32(p) };
            return ret_ar;
        }
        public Form2(int details, int shifts)
        {
            InitializeComponent();
            this.details = details;
            this.shifts = shifts;
        }
    }
}
