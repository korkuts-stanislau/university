using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Coursework_kskr
{
    class InputDate
    {
        /// <summary>
        /// Получение из файла узлов.
        /// </summary>
        /// <returns>узлы</returns>
        static public List<Node> Nodes()
        {
            Node node = new Node();
            List<Node> nodes = new List<Node>();
            StreamReader file = new StreamReader("Nodes.txt");
            while (!file.EndOfStream)
            {
                List<string> str = file.ReadLine().TrimStart().TrimEnd().Split().ToList();
                for (int i = 0; i < str.Count; i++)
                    if (str[i] == "")
                    {
                        str.RemoveAt(i);
                        i--;
                    }
                node = (str.Count == 5 ? new Node(Convert.ToInt32(str[0]), Convert.ToSingle(str[1]), Convert.ToSingle(str[2]), true) : new Node(Convert.ToInt32(str[0]), Convert.ToSingle(str[1]), Convert.ToSingle(str[2]), false));
                nodes.Add(node);
            }
            return (nodes);
        }

        /// <summary>
        /// Получение из файла элементов.
        /// </summary>
        /// <param name="nodes">узлы</param>
        /// <returns>элементы</returns>
        static public List<Element> Elements(List<Node> nodes)
        {
            Element element = new Element();
            List<Element> elements = new List<Element>();
            StreamReader file = new StreamReader("Elements.txt");
            while (!file.EndOfStream)
            {
                List<string> str = file.ReadLine().TrimStart().TrimEnd().Split().ToList();
                for (int i = 0; i < str.Count; i++)
                    if (str[i] == "")
                    {
                        str.RemoveAt(i);
                        i--;
                    }
                element = new Element(Convert.ToInt32(str[0]), nodes[Convert.ToInt32(str[6]) - 1], nodes[Convert.ToInt32(str[7]) - 1], nodes[Convert.ToInt32(str[8]) - 1]);
                elements.Add(element);
            }
            return (elements);
        }

    }
}
