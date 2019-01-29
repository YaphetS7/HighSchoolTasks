using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeCache
{
    class Program
    {
        static void Main(string[] args)
        {
            NativeCache<string> cache = new NativeCache<string>(7);
            cache.Appeal("translator");
            cache.Appeal("video");
            cache.Appeal("google");
            cache.Appeal("yandex");
            cache.Appeal("google");
            cache.Appeal("video");
            cache.Appeal("yandex");
            cache.PrintCache();

            cache.Appeal("vk.com");
            cache.PrintCache();

            cache.Appeal("mts");
            cache.PrintCache();
        }
    }
    class NativeCache<T>
    {
        public int size;
        public int count;
        public string[] slots;
        public T[] values;
        public int[] hits;
        private int last_i;
        public Dictionary<string, T> dict = new Dictionary<string, T>();
        int i;
        public NativeCache(int size)
        {
            count = 0;
            this.size = size * 2;
            slots = new string[this.size];
            for (int i = 0; i < this.size; i++)
                slots[i] = null;
            hits = new int[this.size];
            values = new T[this.size];
            last_i = size + 1;
        }
        public void PrintCache()
        {
            Console.WriteLine();
            Console.WriteLine("Cash/CntOfAppeals is:");
            for (int i = 0; i < size; i++)
                if (slots[i] != null)
                    Console.WriteLine(slots[i] + " " + hits[i]);
        }
        public int Find_index(T value)
        {
            return Hash_fun(value);
        }
       
        private int Hash_fun(T value)
        {
            string s = Convert.ToString(value);
            int result = 0;
            for (int i = 0; i < s.Length; i++)
                result += s[i] - '0';
                
            return result % size;
        }
        public void Appeal(T value)
        {
            i = Hash_fun(value);
            string key = Convert.ToString(value);
            if (!dict.ContainsKey(key))
                dict.Add(key, value);
           
            slots[i] = key;
            if (count >= size / 2)
                ClearSlot(i);

            hits[i]++;
            count++;
        }
        private void ClearSlot(int index)
        {
            int imin = 0, i, min = size + 1;
            for (i = 0; i < size; i++)
                if (slots[i] != null && hits[i] < min && i != index && i != last_i && hits[i] != 0)
                {
                    min = hits[i];
                    imin = i;
                }
           
            dict.Remove(slots[imin]);
            slots[imin] = null;
            count -= min;
            hits[imin] = 0;
            last_i = index;
            
        }
       
    }
}
