using System;
using System.Windows.Forms;

namespace MachineLearn
{
    public partial class Form1 : Form
    {
        int details;
        int shifts;
        public Form1()
        {
            InitializeComponent();
        }
        static void ShowThis()
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                details = Convert.ToInt32(textBox1.Text);
                textBox3.Text = Convert.ToString(details);
                textBox1.Text = "";
            }
            catch
            {
                textBox3.Text = "Вы ввели неверное количество деталей";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                shifts = Convert.ToInt32(textBox2.Text);
                if(shifts == 1 || shifts == 2 || shifts == 3)
                {
                    textBox4.Text = Convert.ToString(shifts);
                    textBox2.Text = "";
                }
                else
                {
                    textBox4.Text = "Введите верное кол-во смен";
                }
            }
            catch
            {
                textBox4.Text = "Введите верное кол-во смен";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int details, shifts, flag = 0;
            try
            {
                details = Convert.ToInt32(textBox3.Text);
                flag = 1;
                shifts = Convert.ToInt32(textBox4.Text);
                label6.Text = "Поехали";
                Form2 form2 = new Form2(details, shifts);
                form2.Show();
            }
            catch
            {
                if(flag == 0)
                    label6.Text = "Вы ввели неверное количество деталей";
                else
                    label6.Text = "Вы ввели неверное количество смен";
            }
        }
    }
}
