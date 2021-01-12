using System;
using DictionaryLib;
using SubjectLib;
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

namespace DictionaryApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Subjects> timetable;
        public MainWindow()
        {
            InitializeComponent();
            DictionaryInitialization();
            ListInitialization();
            SomeValuesInitialization();
        }
        void DictionaryInitialization()
        {
            timetable = new Dictionary<string, Subjects>(new KeyValue<string, Subjects>[0]);
            foreach(string weekDay in new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница"})
            {
                timetable.Add(new KeyValue<string, Subjects>(weekDay, new Subjects()));
            }
        }
        void ListInitialization()
        {
            timetableBox.Items.Clear();
            foreach(KeyValue<string, Subjects> keyValue in timetable)
            {
                timetableBox.Items.Add(keyValue.Key);
                for (int i = 0; i < keyValue.Value.Length; i++)
                {
                    timetableBox.Items.Add("     " + keyValue.Value[i][0] + ": " + keyValue.Value[i][5]
                        + " " + keyValue.Value[i][4] + " " + keyValue.Value[i][6]);
                }
            }
        }
        void SomeValuesInitialization()
        {
            timetable["Понедельник"].AddSubject("Математика", 120, 120, "Зачёт", "Александр",
                "Бабич", "Антонович");
            timetable["Среда"].AddSubject("ООП", 120, 120, "Зачёт", "Константин",
                "Курочка", "Сергеевич");
            timetable["Пятница"].AddSubject("Базы данных", 120, 120, "Зачёт", "Олег",
                "Асенчик", "Даниилович");
            ListInitialization();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timetable[weekDayBox.Text].AddSubject(subjectNameBox.Text,
                int.Parse(lecHoursBox.Text), int.Parse(labHoursBox.Text),
                controlTypeBox.Text, eduFirstNameBox.Text, eduLastNameBox.Text,
                eduMiddleNameBox.Text);
            ListInitialization();
        }
    }
}
