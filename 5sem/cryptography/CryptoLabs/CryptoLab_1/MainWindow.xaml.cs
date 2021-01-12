using CryptoLibrary;
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
        CeasarCipher ceasar;
        PolibiusCipher polibius;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                caesarEnOut.Text = ceasar.Encrypt(caesarEnIn.Text);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                caesarDecOut.Text = ceasar.Decrypt(caesarDecIn.Text);
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
                polibEnOut.Text = polibius.Encrypt(polibEnIn.Text);
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                polibDecOut.Text = polibius.Decrypt(polibDecIn.Text);
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                InitCipher<CeasarCipher>(ceasarKey.Text);
                ceasarKey.Text = default;
                MessageBox.Show("Key is set", "Approved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                InitCipher<PolibiusCipher>(polibKey.Text);
                polibKey.Text = default;
                MessageBox.Show("Key is set", "Approved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void InitCipher<T>(string key) where T : Cipher
        {
            if(typeof(T) == typeof(CeasarCipher))
            {
                ceasar = new CeasarCipher(key);
            }
            else
            {
                polibius = new PolibiusCipher(key);
            }
        }
    }
}
