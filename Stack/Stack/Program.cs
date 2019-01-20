using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        private int count;
        private List<T> list = new List<T>();
        public Stack()
        {
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public T Pop()
        {
            if (count == 0)
                return default(T);
            else
            {
                T temp = list[count - 1];
                list.RemoveAt(count - 1);
                count--;
                return temp;
            }
        }

        public void Push(T val)
        {
            list.Add(val);
            count++;
        }

        public T Peek()
        {
            if (count == 0)
                return default(T);
            else
                return list[count - 1];
        }
    }

}
