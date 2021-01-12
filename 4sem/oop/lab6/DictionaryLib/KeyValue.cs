using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLib
{
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public static bool operator ==(KeyValue<TKey, TValue> item1, KeyValue<TKey, TValue> item2)
        {
            if(item1.Key.Equals(item2.Key) && item1.Value.Equals(item2.Value))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(KeyValue<TKey, TValue> item1, KeyValue<TKey, TValue> item2)
        {
            return !(item1 == item2);
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode() + Value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            KeyValue<TKey, TValue> item = (KeyValue<TKey, TValue>)obj;
            return Key.Equals(item.Key) && Value.Equals(item.Value);
        }
    }
}
