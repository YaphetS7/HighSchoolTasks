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
            for (int i = 0; i < size; i++) slots[i] = null;
            values = new T[size];
        }

        public int HashFun(string key)
        {
            char[] a = new char[key.Length];
            int sum = 0;
            int p_pow = 7;
            int p = 7;
            for (int i = 1; i < key.Length; i++)
            {
                a[i] = key[i];
                sum += (a[i] - '0') * p_pow;
                p_pow = p_pow * p;
            }
            sum += a[0] - '0';
            if (sum < 0)
                sum *= -1;
            return (sum % size);
        }

        public bool IsKey(string key)
        {
            int i = HashFun(key);
            if (slots[i] == key)
            {
                return true;
            }
            else
            {
                for (i = 0; i < size; i++)
                    if (slots[i] == key)
                    {
                        return true;
                    }
                return false;
            }
            // возвращает true если ключ имеется,
            // иначе false
           
        }

        public void Put(string key, T value)
        {
            int i = HashFun(key);
            if (slots[i] == null)
            {
                slots[i] = key;
                values[i] = value;
            }
            else
            {
                for (i = 0; i < size; i++)
                    if (slots[i] == null)
                    {
                        slots[i] = key;
                        values[i] = value;
                        break;
                    }
            }
            // гарантированно записываем 
            // значение value по ключу key
        }

        public T Get(string key)
        {
            int i = HashFun(key);
            if (slots[i] == key)
                return values[i];
            else
            {
                for (i = 0; i < size; i++)
                    if (slots[i] == key)
                    {
                        return values[i];
                    }
                return default(T);
            }
            // возвращает value для key, 
            // или null если ключ не найден
        }
    }
}