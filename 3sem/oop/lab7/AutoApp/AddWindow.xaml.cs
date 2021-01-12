using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoApp
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        MainWindow main;
        public AddWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            InitializeForms();
        }
        public void InitializeForms()
        {
            Load_Text.Visibility = Visibility.Collapsed;
            Passengers_Text.Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Type.SelectedItem.ToString().Contains("Грузопассажирский"))
                {
                    main.automobiles.AddAutomobile("transport", Brand.SelectedItem.ToString(), Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                            Code_Text.Text, Convert.ToInt32(Load_Text.Text), Convert.ToInt32(Passengers_Text.Text));
                }
                else if (Type.SelectedItem.ToString().Contains("Грузовой"))
                {
                    main.automobiles.AddAutomobile("truck", Brand.SelectedItem.ToString(), Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                            Code_Text.Text, load: Convert.ToInt32(Load_Text.Text));
                }
                else if (Type.SelectedItem.ToString().Contains("Пассажирский"))
                {
                    main.automobiles.AddAutomobile("vehicle", Brand.SelectedItem.ToString(), Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                            Code_Text.Text, passengers: Convert.ToInt32(Passengers_Text.Text));
                }
                else
                {
                    throw new Exception("Не выбран тип автомобиля");
                }
                main.InitializeList();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите верные значения");
            }
        }

        private void SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            Load_Text.Visibility = Visibility.Collapsed;
            Passengers_Text.Visibility = Visibility.Collapsed;
            if (Type.SelectedItem.ToString().Contains("Грузопассажирский"))
            {
                Load_Text.Visibility = Visibility.Visible;
                Passengers_Text.Visibility = Visibility.Visible;
            }
            else if (Type.SelectedItem.ToString().Contains("Грузовой"))
            {
                Load_Text.Visibility = Visibility.Visible;
            }
            else if (Type.SelectedItem.ToString().Contains("Пассажирский"))
            {
                Passengers_Text.Visibility = Visibility.Visible;
            }
        }
    }
}
