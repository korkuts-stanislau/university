using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLib
{

    public class Dictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>,
                                            ICollection<KeyValue<TKey, TValue>>
    {
        KeyValue<TKey, TValue>[] keysValues;
        public Dictionary(KeyValue<TKey, TValue>[] keysValues)
        {
            this.keysValues = keysValues;
        }
        public Dictionary()
        {
            this.keysValues = new KeyValue<TKey, TValue>[0];
        }
        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return new DictEnumerator<TKey, TValue>(keysValues);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int Count => keysValues.Length;
        public bool IsReadOnly => false;
        public void Add(KeyValue<TKey, TValue> item)
        {
            KeyValue<TKey, TValue>[] newArr = new KeyValue<TKey, TValue>[this.Count() + 1];
            for(int i = 0; i < this.Count; i++)
            {
                newArr[i] = keysValues[i];
            }
            newArr[this.Count()] = item;
            keysValues = newArr;
        }
        public void Add(TKey key, TValue value)
        {
            KeyValue<TKey, TValue>[] newArr = new KeyValue<TKey, TValue>[this.Count() + 1];
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = keysValues[i];
            }
            newArr[this.Count()] = new KeyValue<TKey, TValue>(key, value);
            keysValues = newArr;
        }
        public void Clear()
        {
            keysValues = new KeyValue<TKey, TValue>[0];
        }
        public bool Contains(KeyValue<TKey, TValue> item)
        {
            for(int i = 0; i < this.Count(); i++)
            {
                if(keysValues[i] == item) //Под вопросом будет ли оно правильно сравнивать
                {
                    return true;
                } 
            }
            return false;
        }
        public bool Contains(TKey key)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                if (keysValues[i].Key.Equals(key)) //Под вопросом будет ли оно правильно сравнивать
                {
                    return true;
                }
            }
            return false;
        }
        public void CopyTo(KeyValue<TKey, TValue>[] array, int arrayIndex)
        {
            for(int i = arrayIndex; i < this.Count && i - arrayIndex < array.Length; i++)
            {
                array[i - arrayIndex] = keysValues[i];
            }
        }
        public bool Remove(KeyValue<TKey, TValue> item)
        {
            if(this.Contains(item))
            {
                KeyValue<TKey, TValue>[] newArr = new KeyValue<TKey, TValue>[this.Count() - 1];
                int flag = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    if(keysValues[i] == item)
                    {
                        flag = 1;
                        continue;
                    }
                    newArr[i - flag] = keysValues[i];
                }
                keysValues = newArr;
                return true;
            }
            return false;
        }
        public bool Remove(TKey key)
        {
            if (this.GetKeys().Contains(key))
            {
                KeyValue<TKey, TValue>[] newArr = new KeyValue<TKey, TValue>[this.Count() - 1];
                int flag = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    if (keysValues[i].Key.Equals(key))
                    {
                        flag = 1;
                        continue;
                    }
                    newArr[i - flag] = keysValues[i];
                }
                keysValues = newArr;
                return true;
            }
            return false;
        }
        public TKey[] GetKeys()
        {
            TKey[] keys = new TKey[this.Count];
            for(int i = 0; i < this.Count; i++)
            {
                keys[i] = keysValues[i].Key;
            }
            return keys;
        }
        public TValue[] GetValues()
        {
            TValue[] values = new TValue[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                values[i] = keysValues[i].Value;
            }
            return values;
        }
        public TValue this[TKey key]
        {
            get
            {
                foreach(KeyValue<TKey, TValue> keyValue in keysValues)
                {
                    if(keyValue.Key.Equals(key))
                    {
                        return keyValue.Value;
                    }
                }
                throw new Exception("Нет такого ключа");
            }
        }
    }
}
