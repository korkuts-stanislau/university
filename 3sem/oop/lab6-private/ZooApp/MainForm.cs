using System;
using System.Windows.Forms;
using ZooLib;

namespace ZooApp
{
    public partial class MainForm : Form
    {
        public PetShop petShop;
        string[][] example = {
            new string[] {"Милана", "кошка", "шерсть", "домик" },
            new string[] {"Мия", "собака", "шерсть", "нет" },
            new string[] {"Анжи", "попугай", "оперение", "клетка" },
            new string[] {"Бэйн", "сова", "оперение", "нет" },
            new string[] {"Элиза", "ящерица", "чешуя", "террариум" },
            new string[] {"Тара", "черепаха", "чешуя", "нет" },
            new string[] {"Дори", "кошка", "шерсть", "нет" },
        };
        public MainForm()
        {
            InitializeComponent();
            petShop = new PetShop(example);
            InitializeList();
        }
        public void InitializeList()
        {
            petList.Items.Clear();
            petList.Items.AddRange(petShop.GetPetList());
        }

        private void tasksBox_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(tasksBox.SelectedItem.ToString())
            {
                case "Кол-во питомцев без жилья":
                    valueLabel.Text = petShop.FindPetsWithoutHome().ToString();
                    comboBox.Items.Clear();
                    return;
                case "Кол-во питомцев по кожному покрову":
                    valueLabel.Text = "Количество";
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(new string[] {"шерсть", "оперение", "чешуя" });
                    return;
                case "Кол-во питомцев по виду":
                    valueLabel.Text = "Количество";
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(new string[] { "кошка", "собака", "попугай", "сова", "ящерица", "черепаха" });
                    return;
                default:
                    MessageBox.Show("Что-то пошло не так!");
                    return;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = comboBox.SelectedItem.ToString();
            if (tasksBox.SelectedItem.ToString().Equals("Кол-во питомцев по кожному покрову"))
            {
                valueLabel.Text = petShop.FindPetsBySkin(comboBox.SelectedItem.ToString()).ToString();
            }
            else
            {
                valueLabel.Text = petShop.FindPetsByType(comboBox.SelectedItem.ToString()).ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                petShop.DeletePet(petList.SelectedItem.ToString().Split(',')[0]);
                InitializeList();
            }
            catch
            {
                MessageBox.Show("Выберите питомца");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPet add = new AddPet(this);
            add.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditPet edit = new EditPet(this, petList.SelectedItem.ToString().Split(new string[] {", "}, StringSplitOptions.None));
                edit.Show();
            }
            catch
            {
                MessageBox.Show("Выделите питомца для редактирования");
            }
        }
    }
}
