using System;
using PolynomLib;
using System.Windows.Forms;

namespace PolynomApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                Polinomial firstPolynomial = new Polinomial(FirstBox.Text);
                Polinomial secondPolynomial;
                double number;
                if(Double.TryParse(SecondBox.Text, out number))
                    Result.Text = $"Результат\n{firstPolynomial * number}";
                else
                {
                    secondPolynomial = new Polinomial(SecondBox.Text);
                    Result.Text = $"Результат:  {firstPolynomial * secondPolynomial}";
                }
            }
            catch
            {
                MessageBox.Show("Введите верные значения");
            }
        }
    }
}
