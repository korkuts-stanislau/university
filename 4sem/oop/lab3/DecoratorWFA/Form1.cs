using System;
using System.IO;
using DecoratorLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecoratorWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "";
            int nBytes = 0;
            try
            {
                text = textBox1.Text;
                nBytes = int.Parse(textBox2.Text);
                using (FileStream stream = new FileStream(@"D:\korkuts-itp21-oop\lab3\WriteFile.txt", FileMode.Append))
                {
                    StreamGetLastNDecorator decoratedStream = new StreamGetLastNDecorator(stream);
                    textBox3.Text = Encoding.UTF8.GetString(decoratedStream.Write(Encoding.UTF8.GetBytes(text), nBytes));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
