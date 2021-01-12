﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_rab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UInt32 a;
        UInt32 LFSR()
        {
            a = ((((a >> 31) ^ (a >> 29) ^ (a >> 28) ^ (a >> 25) ^ (a >> 24) ^ (a >> 23) ^ (a >> 22) ^ (a >> 19) ^ (a >> 17) ^ (a >> 8) ^ (a >> 4) ^ a) & 0x00000001) << 31) | (a >> 2);
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            double zatr_cont = 8; //B
            double zatr_o1 = 55;//C
            double zatr_o2 = 120;//D
            double primes = 0.20 * UInt32.MaxValue;//A
            double p, sum_zatr;
            int proc = 0;
            double min = double.MaxValue;
            int prc = 0;
            a = Convert.ToUInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double n = Convert.ToInt32(textBox3.Text);
            while (proc <= 100)
            {
                p = ((double)proc / 100);
                sum_zatr = 0;
                for (int i = 0; i < n; i++)
                {
                    UInt32 r1 = LFSR();
                    UInt32 r2 = LFSR();
                    if (r1 < p)
                        sum_zatr += zatr_cont;
                    if (r1 < p && r2 < primes)
                        sum_zatr += zatr_o1;
                    if (r1 >= p && r2 < primes)
                        sum_zatr += zatr_o2;
                }
                if (min > sum_zatr)
                {
                    min = sum_zatr;
                    prc = proc;
                }
                textBoxResult.Text = textBoxResult.Text + "Процент контроля: " + proc + "% Затраты на " + n + " партий: " + sum_zatr + "\r\n";
                proc += b;
            }
            textBoxResult.Text = textBoxResult.Text + "\r\n\r\nПроцент контроля c минимальными затратами: " + prc + "%, минимальные затраты: " + min;
        }
    }
}
