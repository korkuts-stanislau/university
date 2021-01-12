using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZooAppLib;
using System.IO;

namespace ZooApp
{
    public partial class ChangeForm : Form
    {
        MainForm main;
        PetShop.Pet petToChange = new PetShop.Pet();
        public ChangeForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            InitializeForms();
            this.typeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.skinBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.houseBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void InitializeForms()
        {
            try
            {
                string info = main.petList.SelectedItem.ToString();
                Regex parse = new Regex(@"Вид: (?<type>\S+), Имя: (?<name>\S+), Покров: (?<skin>\S+), Жилище: (?<house>\S+)");
                textName.Text = parse.Match(info).Groups["name"].Value;
                typeBox.Text = parse.Match(info).Groups["type"].Value;
                skinBox.Text = parse.Match(info).Groups["skin"].Value;
                houseBox.Text = parse.Match(info).Groups["house"].Value;
            }
            catch
            {
                throw new Exception("Не выбран питомец");
            }
        }
        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeInProgram(false);
                ChangeInList(false);
                ChangeInFile(@"C:\korkuts_itp-21_oop\lab6-public\PetList.txt", false);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите правильные данные");
            }
        }
        private void ChangeInProgram(bool isForDelete)
        {
            if(isForDelete)
            {
                main.petList.Items.Remove(main.petList.SelectedItem);
            }
            else if (textName.Text != "")
            {
                string type = typeBox.SelectedItem.ToString();
                string skin = skinBox.SelectedItem.ToString();
                string house = houseBox.SelectedItem.ToString();
                petToChange = new PetShop.Pet(textName.Text, PetShop.StringToType(type), PetShop.StringToSkin(skin), PetShop.StringToHouse(house));
                main.petList.Items[main.petList.SelectedIndex] = petToChange.ToString(false);
            }
            else
                throw new Exception("Введены некорректные данные");
        }
        private void ChangeInFile(string inputPath, bool isForDelete)
        {
            string outputPath = inputPath.Split('.')[0] + "-tmp.txt";
            int ind = main.petList.SelectedIndex;
            using (StreamReader input = new StreamReader(inputPath))
            using (StreamWriter output = new StreamWriter(outputPath))
            {
                string line;
                int i = 0;
                while((line = input.ReadLine()) != null)
                {
                    if (line[0].Equals('#'))
                    {
                        output.WriteLine(line);
                        continue;
                    }
                    if (i != ind)
                        output.WriteLine(line);
                    else if (!isForDelete)
                        output.WriteLine(petToChange.ToString(true));
                    i += 1;
                }
            }
            FileInfo fileToDelete = new FileInfo(inputPath);
            fileToDelete.Delete();
            FileInfo fileToRename = new FileInfo(outputPath);
            fileToRename.MoveTo(inputPath);
        }
        private void ChangeInList(bool isForDelete)
        {
            if(isForDelete)
            {
                PetShop newShop = new PetShop(new PetShop.Pet[main.Shop.PetQuantity - 1]);
                int ind = main.petList.SelectedIndex;
                int j = 0;
                for(int i = 0; i < main.Shop.PetQuantity; i++)
                {
                    if(i != ind)
                    {
                        newShop[j] = main.Shop[i];
                        j -= 1;
                    }
                    j += 1;
                }
                main.Shop = newShop;
            }
            else
            {
                main.Shop[main.petList.SelectedIndex] = petToChange;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ChangeInList(true);
            ChangeInFile(@"C:\korkuts_itp-21_oop\lab6\PetList.txt", true);
            ChangeInProgram(true);
            this.Close();
        }
    }
}
