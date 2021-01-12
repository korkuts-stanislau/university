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
using SubjectLib;
using XmlParserLib;

namespace XmlParserApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Subjects subjects;
        public MainWindow()
        {
            InitializeComponent();
            subjects = new Subjects();
        }
        /// <summary>
        /// Записывает имена дисциплин в список
        /// </summary>
        void RecordToList()
        {
            subjectsList.Items.Clear();
            for(int i = 0; i < subjects.Length; i++)
            {
                subjectsList.Items.Add(subjects[i][0]);
            }
        }
        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            subjects = new Subjects();
            XmlParser.ReadFromXmlFile(subjects);
            subjectsList.SelectedItem = null;
            RecordToList();
        }
        /// <summary>
        /// Запись выбранного элемента в текстовые поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subjectsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] attributes = subjects[subjects.SearchIndexByName(subjectsList.SelectedItem.ToString())];
                subjectNameBox.Text = attributes[0];
                lecHoursBox.Text = attributes[1];
                labHoursBox.Text = attributes[2];
                switch (attributes[3])
                {
                    case "Зачёт":
                        controlTypeBox.SelectedItem = controlTypeBox.Items[0];
                        break;
                    case "Экзамен":
                        controlTypeBox.SelectedItem = controlTypeBox.Items[1];
                        break;
                    case "ЗачётЭкзамен":
                        controlTypeBox.SelectedItem = controlTypeBox.Items[2];
                        break;
                    case "Тест":
                        controlTypeBox.SelectedItem = controlTypeBox.Items[3];
                        break;
                    default:
                        throw new Exception("Что-то пошло не так");
                }
                educatorBox.Text = $"{attributes[5]} {attributes[4]} {attributes[6]}";
            }
            catch(NullReferenceException){  } //При чтении из файла список очищается и 
                                              //объект SelectedItem ни на что не указывает
        }
        /// <summary>
        /// Записывает дисциплины в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlParser.WriteToXmlFile(subjects);
        }
        /// <summary>
        /// Изменение данных о дисциплине
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int lecHours = Convert.ToInt32(lecHoursBox.Text);
                int labHours = Convert.ToInt32(labHoursBox.Text);
                if (lecHours < 0 || lecHours > 200 || labHours < 0 || labHours > 200)
                {
                    throw new Exception("Превышен диапазон часов занятий");
                }
                string[] educator = educatorBox.Text.Split();
                subjects.EditSubject(subjectNameBox.Text, lecHours, labHours, controlTypeBox.Text,
                    educator[1], educator[0], educator[2]);
            }
            catch
            {
                MessageBox.Show("Введены неверный данные");
            }
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            subjects.RemoveSubject(subjectsList.SelectedItem.ToString());
            RecordToList();
        }
        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string[] educator = educatorBox.Text.Split();
            subjects.AddSubject(subjectNameBox.Text, Convert.ToInt32(lecHoursBox.Text), 
                Convert.ToInt32(labHoursBox.Text), controlTypeBox.Text, educator[1], educator[0], educator[2]);
            RecordToList();
        }
    }
}
