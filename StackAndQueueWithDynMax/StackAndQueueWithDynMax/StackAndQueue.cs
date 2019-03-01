using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueueWithDynMax
{
    class StackAndQueue
    {
        static void Main(string[] args)
        {
            
        }
    }
    //класс, реализующий очередь с поддержкой динамического максимума(за О(1) сможем вернуть максимум на текущем "уровне")
    public class SimpleQueue
    {
        private int count;
        //list содержит в себе элементы самой очереди
        private LinkedList<int> list = new LinkedList<int>();
        //list2 содержит в себе максимумы на опр-ном уровне(вспомогательная очередь)
        private LinkedList<int> list2 = new LinkedList<int>();
        public SimpleQueue()
        {
            count = 0;
        }
        private int Max(int val1, int val2)
        {
            if (val1 > val2)
                return val1;
            else
                return val2;
        }
        public void Enqueue(int item)
        {
            //добавляем максимальный элемент на текущем "уровне"(максимумом считаем или новое значение или предыдущее)
            if (count > 0)
                EnqueueMax(Max(item, list2.Last())); 
            else
                EnqueueMax(item);
            list.AddLast(item);
            count++;
        }
        //добавляем текущий максимум
        public void EnqueueMax(int value)
        {
            list2.AddLast(value);
        }
        public int Dequeue()
        {
            if (count == 0)
                return 0;
            else
            {
                int temp = list.First.Value;
                list.RemoveFirst();
                list2.RemoveFirst();
                count--;
                return temp;
            }
        }
        //извлекаем текущий максимум
        public int CurrMax()
        {
            if (count == 0)
                return 0;
            else
            {
                int temp = list2.Last();
                return temp;
            }
        }
        public int Size()
        {
            return count;
        }

    }
    //класс, реализующий стек с поддержкой динамического максимума
    public class Stack
    {
        private int count;
        //list содержит в себе элементы самого стека
        private List<int> list = new List<int>();
        //list2 содержит в себе максимумы на каждом уровне(вспомогательный стек)
        private List<int> list2 = new List<int>();
        public Stack()
        {
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public int Pop()
        {
            if (count == 0)
                return 0;
            else
            {
                //удаляем элементы из двух стеков одновременно
                int temp = list[count - 1];
                list.RemoveAt(count - 1);
                list2.RemoveAt(count - 1);
                count--;
                return temp;
            }
        }
        //извлекаем текущий максимум из вспомогательного list2
        public int CurrMax()
        {
            if (count == 0)
                return 0;
            else
            {
                int temp = list2[count - 1];
                return temp;
            }
        }
        public void Push(int val)
        {
            //добавляем максимальный элемент на текущем "уровне"(максимумом считаем или новое значение или предыдущее)
            if (count > 0)
                PushMax(Max(val, list2[count - 1]));
            else
                PushMax(val);
            list.Add(val);
            count++;
        }
        private int Max(int val1, int val2)
        {
            if (val1 > val2)
                return val1;
            else
                return val2;
        }
        //добавляем максимум в наш вспомогательный список list2
        private void PushMax(int value)
        {
            list2.Add(value);
        }
        //метод, показывающий элемент в верхушке стека
        public int Peek()
        {
            if (count == 0)
                return 0;
            else
                return list[count - 1];
        }
    }
}
