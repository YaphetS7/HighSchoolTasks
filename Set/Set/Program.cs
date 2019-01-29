using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {
        private Dictionary<string, T> dict = new Dictionary<string, T>();
        public PowerSet()
        {

        }

        public int Size()
        {
            return dict.Count;
        }
        public void PrintSet()
        {
            foreach (T val in dict.Values)
                Console.Write(val + "\t");
        }
        public void Put(T value)
        {
            string s;
            s = Convert.ToString(value);
            if (!dict.ContainsKey(s))
                dict.Add(s, value);
            
            // всегда срабатывает
        }

        public bool Get(T value)
        {
            string s = Convert.ToString(value);
            return (dict.ContainsKey(s));
            // возвращает true если value имеется в множестве,
            // иначе false

        }

        public bool Remove(T value)
        {
            string s = Convert.ToString(value);
            if (dict.ContainsKey(s))
            {
                dict.Remove(s);
                return true;
            }
            else
                return false;
            // возвращает true если value удалено
            // иначе false

        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            PowerSet<T> result = new PowerSet<T>();

            foreach (T a in dict.Values)
            {
                if (set2.dict.ContainsValue(a))
                    result.Put(a);
            }

            foreach (T a in set2.dict.Values)
            {
                if (dict.ContainsValue(a) && !result.dict.ContainsValue(a))
                    result.Put(a);
            }

            return result;
            // пересечение текущего множества и set2

        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            PowerSet<T> temp = new PowerSet<T>();
            foreach (T a in dict.Values)
            {
                temp.Put(a);
            }
            foreach (T a in set2.dict.Values)
            {
                if (!temp.dict.ContainsValue(a))
                    temp.Put(a);
            }
            return temp;
            // объединение текущего множества и set2

        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            PowerSet<T> temp = new PowerSet<T>();
            foreach (T a in dict.Values)
            {
                temp.Put(a);
            }
            foreach (T a in set2.dict.Values)
                if (dict.ContainsKey(Convert.ToString(a)))
                    temp.Remove(a);
            return temp;
            // разница текущего множества и set2
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            int k = 0;
            foreach (T a in set2.dict.Values)
                if (dict.ContainsValue(a))
                    k++;
            return (k == set2.dict.Count);
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
        }
    }
}
