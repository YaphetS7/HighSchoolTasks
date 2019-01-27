using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            char[] a = new char[key.Length];
            int sum = 0;
            for (int i = 0; i < key.Length; i++)
            {
                a[i] = key[i];
                sum += a[i] - '0';
            }
            return (sum % size);
        }

        public bool IsKey(string key)
        {
            int i = HashFun(key);
            return (slots[i] == key);
            // возвращает true если ключ имеется,
            // иначе false
           
        }

        public void Put(string key, T value)
        {
            int i = HashFun(key);
            slots[i] = key;
            values[i] = value;
            // гарантированно записываем 
            // значение value по ключу key
        }

        public T Get(string key)
        {
            int i = HashFun(key);
            if (slots[i] == key)
                return values[i];
            else
                return default(T);
            // возвращает value для key, 
            // или null если ключ не найден
        }
    }
}