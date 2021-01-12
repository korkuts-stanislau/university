using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using DatabaseLinq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SubjEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeEducatorsBox();
            InitializeControlBox();
        }
        void InitializeDataGrid()
        {
            subjectsGrid.Items.Clear();
            var subjects = Database.GetSubjects();
            foreach (var subject in subjects)
            {
                subjectsGrid.Items.Add(subject);
            }
        }
        void InitializeEducatorsBox()
        {
            var educators = Database.GetEducators();
            educatorsBox.SelectedValuePath = "Key";
            educatorsBox.DisplayMemberPath = "Value";
            foreach (var edu in educators)
            {
                educatorsBox.Items.Add(new KeyValuePair<int, string>((int)edu.GetType().GetProperty("EducatorId").GetValue(edu), (string)edu.GetType().GetProperty("EducatorName").GetValue(edu)));
            }
        }
        void InitializeControlBox()
        {
            var controls = Database.GetControlTypes();
            controlBox.SelectedValuePath = "Key";
            controlBox.DisplayMemberPath = "Value";
            foreach (var cntrl in controls)
            {
                controlBox.Items.Add(new KeyValuePair<int, string>((int)cntrl.GetType().GetProperty("ControlTypeId").GetValue(cntrl), (string)cntrl.GetType().GetProperty("ControlTypeName").GetValue(cntrl)));
            }
        }
        private void subjectsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                educatorsBox.Text = subjectsGrid.SelectedItem.GetType().GetProperty("Educator").GetValue(subjectsGrid.SelectedItem).ToString();
                controlBox.Text = subjectsGrid.SelectedItem.GetType().GetProperty("ControlTypeName").GetValue(subjectsGrid.SelectedItem).ToString();
                subjectNameBox.Text = subjectsGrid.SelectedItem.GetType().GetProperty("SubjectName").GetValue(subjectsGrid.SelectedItem).ToString();
                lectureHoursBox.Text = subjectsGrid.SelectedItem.GetType().GetProperty("LectureHours").GetValue(subjectsGrid.SelectedItem).ToString();
                labHoursBox.Text = subjectsGrid.SelectedItem.GetType().GetProperty("LabHours").GetValue(subjectsGrid.SelectedItem).ToString();
            }
            catch
            {

            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Database.AddSubject(subjectNameBox.Text, int.Parse(lectureHoursBox.Text), int.Parse(labHoursBox.Text), (int)controlBox.SelectedItem.GetType().GetProperty("Key").GetValue(controlBox.SelectedItem), (int)educatorsBox.SelectedItem.GetType().GetProperty("Key").GetValue(educatorsBox.SelectedItem));
            InitializeDataGrid();
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.EditSubject((int)subjectsGrid.SelectedItem.GetType().GetProperty("SubjectId").GetValue(subjectsGrid.SelectedItem), subjectNameBox.Text, int.Parse(lectureHoursBox.Text), int.Parse(labHoursBox.Text), (int)controlBox.SelectedItem.GetType().GetProperty("Key").GetValue(controlBox.SelectedItem), (int)educatorsBox.SelectedItem.GetType().GetProperty("Key").GetValue(educatorsBox.SelectedItem));
                InitializeDataGrid();
            }
            catch
            {
                MessageBox.Show("Выберите поле для редактирования");
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.DeleteSubject((int)subjectsGrid.SelectedItem.GetType().GetProperty("SubjectId").GetValue(subjectsGrid.SelectedItem));
                InitializeDataGrid();
            }
            catch
            {
                MessageBox.Show("Выберите поле для удаления");
            }
        }
    }
}
