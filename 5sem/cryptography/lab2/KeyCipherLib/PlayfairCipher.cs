using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyCipherLib
{
    public class PlayfairCipher : ICipher
    {
        string _key;
        char[,] _cipherMatrix;
        public PlayfairCipher(string key)
        {
            _key = key;
        }

        private char[,] GetCipherMatrix(string key)
        {
            List<char> charListWithOrder = GetCharListInOrder(key);
            if(charListWithOrder.Count != 72)
            {
                throw new Exception("Введён неверный ключ");
            }
            char[,] cipherMatrix = new char[8, 9];
            int i = 0;
            foreach(char uniqueChar in charListWithOrder)
            {
                cipherMatrix[i / 9, i % 9] = uniqueChar;
                i++;
            }
            return cipherMatrix;
        }

        private List<char> GetCharListInOrder(string text) // Длина выходного массива должна быть 72, если нет, то введен неверный ключ
        {
            List<char> charsInOrder = GetUniqueCharactersFromStringWithOrder(text);
            List<string> allChars = new List<string>("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчщъыьэюя,.!:; ".Split(""));
            foreach(string c in allChars)
            {
                if(!charsInOrder.Contains(c.ToCharArray()[0]))
                {
                    charsInOrder.Add(c.ToCharArray()[0]);
                }
            }
            return charsInOrder;
        }

        private List<char> GetUniqueCharactersFromStringWithOrder(string text)
        {
            List<char> buffer = new List<char>();
            foreach(char c in text)
            {
                if(!buffer.Contains(c))
                {
                    buffer.Add(c);
                }
            }
            return buffer;
        }

        public string Decode(string textToDecode)
        {
            return new CaesarForCheat().Decode(textToDecode, _key);
        }

        public string Encode(string textToEncode)
        {
            return new CaesarForCheat().Encode(textToEncode, _key);
        }

        private string EncodeBigram(string bigram)
        {
            char first = bigram.ToCharArray()[0];
            char second = bigram.ToCharArray()[1];
            char changedFirst = 'X';
            char changedSecond = 'X';
            if(getElementIndex(first)[0] == getElementIndex(second)[0])
            {
                for(int j = 0; j < _cipherMatrix.GetLength(1) - 1; j++)
                {

                }
            }
            throw new NotImplementedException();
        }

        private int[] getElementIndex(char element)
        {
            for(int i = 0; i < _cipherMatrix.GetLength(0); i++)
                for(int j = 0; j < _cipherMatrix.GetLength(1); j++)
                {
                    if(element == _cipherMatrix[i, j])
                    {
                        return new int[] { i, j };
                    }
                }
            throw new Exception("Нет такого элемента");
        }

        private List<string> CreateBigrams(string text)
        {
            char[] textChars = text.ToCharArray();
            List<string> bigrams = new List<string>();
            for (int i = 0; i < textChars.Length; i += 2)
            {
                if (i == textChars.Length)
                {
                    bigrams.Add(textChars[i - 1] + "Ь");
                }
                else
                {
                    if (textChars[i] == textChars[i + 1])
                    {
                        bigrams.Add(textChars[i] + "Ь");
                        i -= 1;
                    }
                    else
                    {
                        bigrams.Add(textChars[i] + textChars[i + 1].ToString());
                    }
                }
            }
            return bigrams;
        }
    }
}
