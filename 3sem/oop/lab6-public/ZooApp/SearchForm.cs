using System;
using System.Windows.Forms;
using ZooAppLib;

namespace ZooApp
{
    public partial class SearchForm : Form
    {
        PetShop shop;
        public SearchForm(PetShop shop)
        {
            InitializeComponent();
            this.shop = shop;
            this.tasksBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.valueBox.DropDownStyle = ComboBoxStyle.DropDownList;
            valueBox.Visible = false;
            label2.Visible = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!tasksBox.SelectedItem.Equals("Количество питомцев, которым нужно жильё") && valueBox.Text.Equals(""))
                    throw new Exception("Введите данные");
                if (tasksBox.SelectedItem.Equals("Количество питомцев, которым нужно жильё"))
                {
                    outputBox.Text = FindHomelessPets().ToString();
                }
                else if (tasksBox.SelectedItem.Equals("Количество питомцев по кожному покрову"))
                {
                    outputBox.Text = FindPetsBySkin(valueBox.Text).ToString();
                }
                else
                {
                    outputBox.Text = FindPetsByType(valueBox.Text).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Вы ввели неверные параметры");
            }
        }
        private int FindHomelessPets()
        {
            int count = 0;
            for(int i = 0; i < shop.PetQuantity; i++)
                if (shop[i].House.Equals(House.No))
                    count += 1;
            return count;
        }
        private int FindPetsBySkin(string skin)
        {
            int count = 0;
            for (int i = 0; i < shop.PetQuantity; i++)
                if (shop[i].Skin.Equals(PetShop.StringToSkin(skin)))
                    count += 1;
            return count;
        }
        private int FindPetsByType(string type)
        {
            int count = 0;
            for (int i = 0; i < shop.PetQuantity; i++)
                if (shop[i].Type.Equals(PetShop.StringToType(type)))
                    count += 1;
            return count;
        }

        private void tasksBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(tasksBox.SelectedItem.Equals("Количество питомцев, которым нужно жильё"))
            {
                valueBox.Visible = false;
                label2.Visible = false;
            }
            else if(tasksBox.SelectedItem.Equals("Количество питомцев по кожному покрову"))
            {
                valueBox.Visible = true;
                label2.Visible = true;
                valueBox.Items.Clear();
                valueBox.Items.AddRange(new string[] { "шерсть", "чешуя", "перья" });
            }
            else
            {
                valueBox.Visible = true;
                label2.Visible = true;
                valueBox.Items.Clear();
                valueBox.Items.AddRange(new string[] { "кошка", "собака", "хомяк", "змея", "ящерица", "черепаха", "попугай", "сова", "ворона" });
            }
        }
    }
}