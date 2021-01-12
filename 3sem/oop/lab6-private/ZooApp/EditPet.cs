using System;
using System.Windows.Forms;

namespace ZooApp
{
    public partial class EditPet : Form
    {
        MainForm main;
        string[] petInfo;
        public EditPet(MainForm main, string[] petToEdit)
        {
            InitializeComponent();
            this.main = main;
            petInfo = petToEdit;
            InitializeForms();
        }
        private void InitializeForms()
        {
            nameBox.Text = petInfo[0];
            typeBox.Text = petInfo[1];
            skinBox.Text = petInfo[2];
            houseBox.Text = petInfo[3];
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                main.petShop.ChangePet(new string[] { nameBox.Text, typeBox.SelectedItem.ToString(), skinBox.SelectedItem.ToString(), houseBox.SelectedItem.ToString() });
                main.InitializeList();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Вы ввели неправильное имя");
            }
        }
    }
}
