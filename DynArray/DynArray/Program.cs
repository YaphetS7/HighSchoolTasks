﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity = 16;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }
        public void MakeArray(int new_capacity)
        {
            capacity = new_capacity;
            if (new_capacity > 16)
            {
                T[] temp = new T[new_capacity];
                if (array != null)
                    array.CopyTo(temp, 0);
                array = new T[new_capacity];
                if (array != null)
                    temp.CopyTo(array, 0);
            }
            else
            {
                T[] temp = new T[new_capacity];
                if (array != null)
                    array.CopyTo(temp, 0);
                array = new T[new_capacity];
                if (array != null)
                    temp.CopyTo(array, 0);
            }
        }

        public T GetItem(int index)
        {
            if (index >= 0 && index < count)
                return array[index];
            else
                return default(T); 
        }

        public void Append(T itm)
        {
            if (count == capacity)
                MakeArray(capacity * 2);
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            try
            {
                if (index <= count && index >= 0)
                {
                    if (index == count)
                    {
                        Append(itm);
                    }
                    else
                    {
                        if (count == capacity)
                            MakeArray(capacity * 2);
                        count++;
                        for (int q = count - 1; q >= index; q--)
                            array[q + 1] = array[q];
                        array[index] = itm;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int j = index + 1; j < count; j++)
                    array[j - 1] = array[j];
                count--;
                if (count < capacity * 0.5)
                {
                    if (capacity / 1.5 > 16)
                        MakeArray(Convert.ToInt32(capacity / 1.5));
                    else
                        MakeArray(16);
                }
            }
        }
    }
}