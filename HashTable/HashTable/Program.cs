using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            char[] a = new char[value.Length];
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += a[i] - '0';
            }
            return (sum % size);
            // всегда возвращает корректный индекс слота
            //return 0;
        }

        public int SeekSlot(string value)
        {
            int i;
            i = HashFun(value);
            while (i < size && slots[i] != null)
            {
                i += step;
            }
            if (i >= size)
            {
                i = 0;
                while (i < size && slots[i] != null)
                    i++;
            }
            if (i >= size)
                return -1;
            return i;
            // находит индекс пустого слота для значения, или -1
            //return -1;
        }

        public int Put(string value)
        {
            int i;
            i = SeekSlot(value);
            if (i != -1)
            {
                slots[i] = value;
            }
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return i;
        }

        public int Find(string value)
        {
            int i = HashFun(value);
            if (value == slots[i])
                return i;
            else
            {
                for (i = 0; i < size; i++)
                    if (slots[i] == value)
                        return i;
                return -1;
            }
            // находит индекс слота со значением, или -1
            //return -1;
        }
    }

}