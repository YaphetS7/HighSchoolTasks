using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        private System.Collections.BitArray bit;
        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            bit = new System.Collections.BitArray(f_len);
            
            // создаём битовый массив длиной f_len ...
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int sum = (int)str1[0];
            for (int i = 1; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                sum = (sum * 17 + code) % filter_len;
            }
            // реализация ...
            return (sum % filter_len);
        }
        public int Hash2(string str1)
        {
            // 223
            int sum = (int)str1[0];
            for (int i = 1; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                sum = (sum * 223 + code) % filter_len;
            }
            // реализация ...
            return (sum % filter_len);
        }

        public void Add(string str1)
        {
            bit[Hash1(str1)] = true;
            bit[Hash2(str1)] = true;
        }

        public bool IsValue(string str1)
        {
            return (bit[Hash1(str1)] && bit[Hash2(str1)]);
        }
    }
}
