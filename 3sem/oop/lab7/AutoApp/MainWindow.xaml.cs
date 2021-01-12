using System;
using System.Windows;
using AutoLib;

namespace AutoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AutomobileBase automobiles;
        string[] example = new string[]
        {
            "Грузопассажирский, BMW, 1998, 105406, 1, 10000, 10",
            "Грузовой, Audi, 2005, 61501, 2, 15000",
            "Пассажирский, Nissan, 2009, 32098, 3, 20",
            "Пассажирский, Ford, 2001, 75804, 4, 16",
            "Грузовой, Peugeot, 2003, 67512, 5, 8000",
            "Грузопассажирский, Mazda, 1995, 143918, 6, 5000, 15",
            "Грузовой, Toyota, 2011, 20134, 7, 25000",
            "Грузовой, Volkswagen, 2018, 4612, 8, 30000",
            "Грузопассажирский, Renault, 2004, 40567, 9, 6000, 6",
            "Пассажирский, Mercedes, 1999, 118904, 10, 30"
        };
        public MainWindow()
        {
            InitializeComponent();
            InitializeAutoBase();
            InitializeList();
        }
        private void InitializeAutoBase()
        {
            automobiles = new AutomobileBase(example);
        }
        public void InitializeList()
        {
            Automobiles.Items.Clear();
            for (int i = 0; i < automobiles.BaseLength; i++)
                Automobiles.Items.Add(automobiles[i].ToString());
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow(this);
            add.Show();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditWindow add = new EditWindow(this);
                add.Show();
            }
            catch
            {
                MessageBox.Show("Выберите автомобиль");
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                automobiles.DeleteAutomobile(AutomobileBase.GetAutoCode(Automobiles.SelectedItem.ToString()));
                InitializeList();
            }
            catch
            {
                MessageBox.Show("Выберите автомобиль для удаления");
            }
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            switch(Tasks_Box.Text)
            {
                case "":
                    MessageBox.Show("Выберите что посчитать");
                    return;
                case "Посчитать среднюю пассажироёмкость и грузоподъёмность по всем автомобилям":
                    double load = automobiles.FindAverageLoadAndPassengers()[0];
                    double passengers = automobiles.FindAverageLoadAndPassengers()[1];
                    MessageBox.Show($"Средняя грузоподъёмность {load}\nСредняя пассажироёмкость {passengers}", "Результат");
                    return;
                case "Посчитать средний пробег по все грузовым автомобилям":
                    MessageBox.Show(automobiles.FindAverageMilleage("truck").ToString(), "Результат");
                    return;
                case "Посчитать средний пробег по грузопассажирским автомобилям":
                    MessageBox.Show(automobiles.FindAverageMilleage("transport").ToString(), "Результат");
                    return;
                default:
                    throw new Exception("Что-то пошло не так");
            }
        }
    }
}
