using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        private int count;
        private LinkedList<T> list = new LinkedList<T>();
        public Deque()
        {
            count = 0;
        }

        public void AddFront(T item)
        {
            list.AddFirst(item);
            count++;
        }

        public void AddTail(T item)
        {
            list.AddLast(item);
            count++;
        }

        public T RemoveFront()
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

        public T RemoveTail()
        {
            if (count == 0)
                return default(T);
            else
            {
                T temp = list.Last.Value;
                list.RemoveLast();
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
