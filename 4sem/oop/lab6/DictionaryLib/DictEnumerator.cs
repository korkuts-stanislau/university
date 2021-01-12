using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLib
{
    class DictEnumerator<TKey, TValue> : IEnumerator<KeyValue<TKey, TValue>>
    {
        KeyValue<TKey, TValue>[] keysValues;
        int position = -1;
        public DictEnumerator(KeyValue<TKey, TValue>[] keysValues)
        {
            this.keysValues = keysValues;
        }
        public KeyValue<TKey, TValue> Current
        {
            get
            {
                if (position == -1 || position > keysValues.Length)
                    throw new InvalidOperationException();
                return keysValues[position];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();
        public bool MoveNext()
        {
            if (position < keysValues.Length - 1)
            {
                position += 1;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
}
