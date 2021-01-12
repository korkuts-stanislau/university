using System;
using System.Windows.Forms;

namespace ZooApp
{
    public partial class AddPet : Form
    {
        MainForm main;
        public AddPet(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if(nameBox.Text.Equals(String.Empty) || typeBox.Text.Equals(String.Empty) || skinBox.Text.Equals(String.Empty) || houseBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Что-то здесь не так!");
                return;
            }
            main.petShop.AddPet(new string[] { nameBox.Text, typeBox.Text, skinBox.Text, houseBox.Text });
            main.InitializeList();
            this.Close();
        }
    }
}
