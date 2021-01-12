using System;
using System.Windows.Forms;
using ZooAppLib;

namespace ZooApp
{
    public partial class MainForm : Form
    {
        public PetShop Shop { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Shop = new PetShop();
            for(int i = 0; i < Shop.PetQuantity; i++)
            {
                petList.Items.Add(Shop[i].ToString(false));
            }
        }
        public void FormReload()
        {
            petList.Items.Add(Shop[Shop.PetQuantity - 1].ToString(false));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm add = new AddForm(this);
            add.Show();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeForm change = new ChangeForm(this);
                change.Show();
            }
            catch
            {
                MessageBox.Show("Выберите питомца для редактирования.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(this.Shop);
            search.Show();
        }
    }
}
