using System;
using System.Windows;
using System.Windows.Controls;
using AutoLib;

namespace AutoApp
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow main;
        public EditWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            InitializeForms();
        }
        public void InitializeForms()
        {
            try
            {
                string[] data = main.Automobiles.SelectedItem.ToString().Split(new string[] {", " }, StringSplitOptions.None);
                switch(data[0])
                {
                    case "Грузопассажирский":
                        Type.SelectedIndex = 0;
                        Load_Text.Text = data[5];
                        Passengers_Text.Text = data[6];
                        break;
                    case "Грузовой":
                        Type.SelectedIndex = 1;
                        Load_Text.Text = data[5];
                        break;
                    case "Пассажирский":
                        Type.SelectedIndex = 2;
                        Passengers_Text.Text = data[6];
                        break;
                    default:
                        MessageBox.Show("Что-то пошло не так");
                        break;
                }
                switch(data[1])
                {
                    case "BMW":
                        Brand.SelectedIndex = 0;
                        break;
                    case "Audi":
                        Brand.SelectedIndex = 1;
                        break;
                    case "Nissan":
                        Brand.SelectedIndex = 2;
                        break;
                    case "Ford":
                        Brand.SelectedIndex = 3;
                        break;
                    case "Peugeot":
                        Brand.SelectedIndex = 4;
                        break;
                    case "Mazda":
                        Brand.SelectedIndex = 5;
                        break;
                    case "Toyota":
                        Brand.SelectedIndex = 6;
                        break;
                    case "Volkswagen":
                        Brand.SelectedIndex = 7;
                        break;
                    case "Renault":
                        Brand.SelectedIndex = 8;
                        break;
                    case "Mercedes":
                        Brand.SelectedIndex = 9;
                        break;
                    default:
                        break;
                }
                Release_Date_Text.Text = data[2];
                Milleage_Text.Text = data[3];
                Code_Text.Text = data[4];
            }
            catch
            {
                throw new Exception("Не выбран автомобиль");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Automobile newAutomobile;
                if (Type.SelectedItem.ToString().Contains("Грузопассажирский"))
                {
                    newAutomobile = new Transport(Brand.Text, Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                        Code_Text.Text, Convert.ToInt32(Load_Text.Text), Convert.ToInt32(Passengers_Text.Text));
                }
                else if (Type.SelectedItem.ToString().Contains("Грузовой"))
                {
                    newAutomobile = new Truck(Brand.Text, Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                        Code_Text.Text, Convert.ToInt32(Load_Text.Text));
                }
                else if (Type.SelectedItem.ToString().Contains("Пассажирский"))
                {
                    newAutomobile = new Vehicle(Brand.Text, Convert.ToInt32(Release_Date_Text.Text), Convert.ToInt32(Milleage_Text.Text),
                        Code_Text.Text, Convert.ToInt32(Passengers_Text.Text));
                }
                else
                    throw new Exception("Что-то пошло не так");
                main.automobiles.EditAutomobile(Code_Text.Text, newAutomobile);
                main.InitializeList();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите верные значения полей");
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
