using System;
using System.Collections.Generic;

namespace UniversallyHashing
{

    public delegate long Func(string value, long size);

    class UniversallyHashing
    {
        static void Main(string[] args)
        {
            List<Func> list = new List<Func>();
            Func func1 = Hash1;
            Func func2 = Hash1;
            Func func3 = Hash3;
            list.Add(func1);
            list.Add(func2);
            list.Add(func3);
            HashTable a = new HashTable(17, 3, list);
        }
        public static long Hash1(string value, long size)
        {
            char[] a = new char[value.Length];
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += a[i] - '0';
            }
            return (sum % size);
        }
        public static long Hash2(string value, long size)
        {
            char[] a = new char[value.Length];
            long sum = 0;
            long p_pow = 7;
            long p = 7;
            for (int i = 1; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += (a[i] - '0') * p_pow;
                p_pow = p_pow * p;
            }
            sum += a[0] - '0';
            return (sum % size);
        }
        public static long Hash3(string value, long size)
        {
            char[] a = new char[value.Length];
            long sum = 0;
            long p_pow = value.Length;
            if (p_pow > 31)
                p_pow = 53;
            else
                p_pow = 31;
            long p = p_pow;
            for (int i = 1; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += (a[i] - '0') * p_pow;
                p_pow = (p_pow * p);
            }
            sum += a[0] - '0';
            return (sum % size);
        }
        
    }
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        private Func function;
        Random rand = new Random();
        public HashTable(int sz, int stp, List<Func> list)
        {
            function = list[rand.Next(0, list.Count)];
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }
      
        public long HashFun(string value)
        {
            return function(value, size);
            // всегда возвращает корректный индекс слота
            //return 0;
        }

        public long SeekSlot(string value)
        {
            long i;
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

        public long Put(string value)
        {
            long i;
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

        public long Find(string value)
        {
            long i = HashFun(value);
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
