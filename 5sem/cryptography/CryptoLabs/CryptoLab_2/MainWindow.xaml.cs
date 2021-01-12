using CipherLibrary;
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
        MultiplicationCipher multiplicationCipher;
        VegenereCipher vegenereCipher;
        PermutationCipher permutationCipher;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                multEnOut.Text = multiplicationCipher.Encrypt(multEnIn.Text);
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
                multDecOut.Text = multiplicationCipher.Decrypt(multDecIn.Text);
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
                vegEnOut.Text = vegenereCipher.Encrypt(vegEnIn.Text);
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
                vegDecOut.Text = vegenereCipher.Decrypt(vegDecIn.Text);
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                permEnOut.Text = permutationCipher.Encrypt(permEnIn.Text);
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

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                permDecOut.Text = permutationCipher.Decrypt(permDecIn.Text);
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
                InitCipher<MultiplicationCipher>(multKey.Text);
                multKey.Text = default;
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
                InitCipher<VegenereCipher>(vegKey.Text);
                vegKey.Text = default;
                MessageBox.Show("Key is set", "Approved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                InitCipher<PermutationCipher>(permKey.Text);
                permKey.Text = default;
                MessageBox.Show("Key is set", "Approved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void InitCipher<T>(string key) where T : Cipher
        {
            if (typeof(T) == typeof(MultiplicationCipher))
            {
                multiplicationCipher = new MultiplicationCipher(key);
            }
            else if (typeof(T) == typeof(VegenereCipher))
            {
                vegenereCipher = new VegenereCipher(key);
            }
            else
            {
                permutationCipher = new PermutationCipher(key);
            }
        }
    }
}
