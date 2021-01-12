using CipherLibrary;
using CryptoLibrary;
using FeistelLibrary;
using System;
using System.Collections.Generic;
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

namespace CryptoLabs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FeistrellCipher feistrellCipher;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitCipher(string key, int shift) 
        {
            feistrellCipher = new FeistrellCipher(key, shift);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InitCipher(feiKey.Text, Convert.ToInt32(feiShift.Text));
                feiShift.Text = default;
                feiKey.Text = default;
                MessageBox.Show("Key is set", "Approved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                feiEnOut.Text = feistrellCipher.Encrypt(feiEnIn.Text);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Key is not set", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                feiDecOut.Text = feistrellCipher.Decrypt(feiDecIn.Text);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Key is not set", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
