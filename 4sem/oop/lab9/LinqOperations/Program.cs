using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", new StreamReader(@"D:\korkuts-itp21-oop\lab9\Лермонтов-Нищий.txt").ReadToEnd().Split(new char[] { ' ', '\r', '\n', ',', ';', '.', '!', '?' }).Where(word => word != "").Select(word => string.Concat(word.Where(char.IsLetter).ToArray())).Select(word => word.ToLower()).Where(word => word.Length >= 4).Distinct().ToArray()));
            Console.ReadKey();
        }
    }
}