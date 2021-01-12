using KeyCipherLib;
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

namespace CipherGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCipherTypesBox();
            encodeRarioButton.IsChecked = true;
        }
        private void InitializeCipherTypesBox()
        {
            cipherTypeBox.Items.Add("Матричный метод");
            cipherTypeBox.Items.Add("Метод поворотной решетки");
            cipherTypeBox.Items.Add("Метод Плейфера");
            cipherTypeBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ICipher cipher;
                switch (cipherTypeBox.SelectedItem.ToString())
                {
                    case "Матричный метод":
                        cipher = new MatrixProductionCipher(enterKeyBox.Text);
                        break;
                    case "Метод поворотной решетки":
                        cipher = new RotateSharpCipher();
                        break;
                    case "Метод Плейфера":
                        cipher = new PlayfairCipher(enterKeyBox.Text);
                        break;
                    default:
                        throw new Exception("Что-то пошло не так");
                }
                if((bool)encodeRarioButton.IsChecked)
                {
                    cipherTextBox.Text = cipher.Encode(enterTextBox.Text);
                }
                else
                {
                    cipherTextBox.Text = cipher.Decode(enterTextBox.Text);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
