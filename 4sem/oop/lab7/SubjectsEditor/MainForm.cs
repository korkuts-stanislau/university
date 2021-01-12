using System;
using ADO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubjectsEditor
{
    public partial class MainForm : Form
    {
        Database database;
        public MainForm()
        {
            InitializeComponent();
            database = new Database();
            InitializeControlBox();
            InitializeEducators();
            InitializeSubjectsList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                Subject subject = new Subject
                {
                    Name = subjectNameBox.Text,
                    lecHours = int.Parse(lecHoursBox.Text),
                    labHours = int.Parse(labHoursBox.Text),
                    ControlType = controlTypesBox.Text,
                    Educator = educatorBox.Text
                };
                database.AddSubject(subject);
                InitializeSubjectsList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                Subject subject = new Subject
                {
                    Name = subjectNameBox.Text,
                    lecHours = int.Parse(lecHoursBox.Text),
                    labHours = int.Parse(labHoursBox.Text),
                    ControlType = controlTypesBox.Text,
                    Educator = educatorBox.Text
                };
                database.EditSubject(subject);
                InitializeSubjectsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                database.DeleteSubject(subjectsBox.SelectedItem.ToString());
                InitializeSubjectsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void InitializeControlBox()
        {
            controlTypesBox.Items.AddRange(database.GetControlTypes());
        }
        void InitializeEducators()
        {
            educatorBox.Items.AddRange(database.GetEducators());
        }
        void InitializeSubjectsList()
        {
            subjectsBox.Items.Clear();
            database.GetSubjects();
            foreach(Subject sub in database.subjects)
            {
                subjectsBox.Items.Add(sub.Name);
            }
        }

        private void subjectsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = subjectsBox.SelectedIndex;
            subjectNameBox.Text = database.subjects[idx].Name;
            lecHoursBox.Text = database.subjects[idx].lecHours.ToString();
            labHoursBox.Text = database.subjects[idx].labHours.ToString();
            controlTypesBox.SelectedItem = database.subjects[idx].ControlType;
            educatorBox.SelectedItem = database.subjects[idx].Educator;
        }
    }
}
