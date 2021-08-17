using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableDemo
{
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public struct KeyValue<k, v>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        protected int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            return default(V);
        }
        //Adding the keys and values through the linked list
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            linkedList.AddLast(item);
            Console.WriteLine(item.Key + " " + item.Value);
        }
        //Displaying the all keys and values
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
        //shows the frequence(like key) of the values
        public void GetFrequence(V value)
        {
            int frequence = 0;
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.Value.Equals(value))
                        frequence++;
                }
            }
            Console.WriteLine("Frequency is : {1}", value, frequence);
        }
    }

}


