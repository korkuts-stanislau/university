using System;
using System.IO;
using System.Windows.Forms;
using ZooAppLib;

namespace ZooApp
{
    public partial class AddForm : Form
    {
        MainForm main;
        PetShop.Pet petToAdd;
        public AddForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            this.typeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.skinBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.houseBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreatePet();
                WritePetToFile(@"C:\korkuts_itp-21_oop\lab6\PetList.txt");
                main.Shop = main.Shop + petToAdd;
                main.FormReload();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Вы ввели неверные значения");
            }
        }
        private void CreatePet()
        {
            string name = textName.Text;
            string type = typeBox.SelectedItem.ToString();
            string skin = skinBox.SelectedItem.ToString();
            string house = houseBox.SelectedItem.ToString();
            petToAdd = new PetShop.Pet(name, PetShop.StringToType(type), PetShop.StringToSkin(skin), PetShop.StringToHouse(house));
        }
        private void WritePetToFile(string path)
        {
            using (StreamWriter stream = new StreamWriter(path, true)) //Инициализация массивов
            {
                stream.WriteLine(petToAdd.ToString(true));
            }
        }
    }
}
