using System;
using System.Collections.Generic;
namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private int count;
        private LinkedList<T> list = new LinkedList<T>();
        public Queue()
        {
            count = 0;
        }

        public void Enqueue(T item)
        {
            list.AddLast(item);
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                return default(T);
            else
            {
                T temp = list.First.Value;
                list.RemoveFirst();
                count--;
                return temp;
            }
        }

        public int Size()
        {
            return count;
        }

    }
}

