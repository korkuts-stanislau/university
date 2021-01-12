using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] table = algoritms2.ShowVizener();
            int menu = -1;
            while (menu != 0)
            {
                Console.WriteLine("1.Зашифровать");
                Console.WriteLine("2.Расшифровать");
                Console.WriteLine("0.Выход");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Введите текст для зашифровки");
                        string text = Console.ReadLine();
                        string result = algoritms2.Task1_2(text, table);
                        Console.WriteLine(result);
                        break;
                    case 2:
                        Console.WriteLine("Введите текст для расшифровки");
                        text = Console.ReadLine();
                        result = algoritms2.Task1_1(text, table);
                        Console.WriteLine(result);
                        break;
                }
            }
        }
    }
}
