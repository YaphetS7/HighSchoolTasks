using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ImmutableStackAndQueue
{
    class ImmStackAndQueue
    {
        static void Main(string[] args)
        {
           
           
        }
    }
    //класс, реализующий иммутабельную очередь
    public class ImmQueue<T>
    {
        private LinkedList<T> list = new LinkedList<T>();
        //метод, добавляющий value в конец неизменяемой очереди и возвращает новую очередь
        public ImmQueue<T> Enqueue(T value)
        {
            //создаем объект данного класса, который будем возвращать
            ImmQueue<T> temp = new ImmQueue<T>();
            LinkedListNode<T> node = list.First;
            //копируем значения из данного this-класса в наш обЪект, который мы только что создали
            while (node != null)
            {
                temp.list.AddLast(node.Value);
                node = node.Next;
            }
            //добавляем value не в this-класс, а в созданный только что объект и возвращаем его
            temp.list.AddLast(value);
            return temp;
        }
        //метод, извлекающий элемент из начала неизменяемой очереди и возвращающий новую очередь
        public ImmQueue<T> Dequeue()
        {
            ImmQueue<T> temp = new ImmQueue<T>();
            LinkedListNode<T> node = list.First;
            //копируем значения из данного this-класса в наш обЪект, который мы только что создали
            while (node != null)
            {
                temp.list.AddLast(node.Value);
                node = node.Next;
            }
            //удаляем value не в this-классе, а в созданном только что объекте и возвращаем его
            temp.list.RemoveFirst();
            return temp;
        }
        //аналог метода Peek() в стеке, показывающий первый элемент очереди
        public T First()
        {
            return list.First();
        }
        
    }
    //класс, реализующий иммутабельный стек
    public class ImmStack<T>
    {
        private List<T> list = new List<T>();
        //метод, добавляющий value в неизменяемый стек и возвращающий новый стек
        public ImmStack<T> Push(T value)
        {
            //создаем объект данного класса, который будем возвращать
            ImmStack<T> temp = new ImmStack<T>();
            //копируем значения из данного this-класса в наш обЪект, который мы только что создали
            foreach (T item in list)
            {
                temp.list.Add(item);
            }
            temp.list.Add(value);
            return temp;
        }
        //метод, извлекающий элемент из верхушки неизменяемого стека и возвращающий новый стек
        public ImmStack<T> Pop()
        {
            //создаем объект данного класса, который будем возвращать
            ImmStack<T> temp = new ImmStack<T>();
            //копируем значения из данного this-класса в наш обЪект, который мы только что создали
            foreach (T item in list)
            {
                temp.list.Add(item);
            }
            temp.list.RemoveAt(temp.list.Count - 1);
            return temp;
        }
        //показывает верхний элемент стека, не удаляя его
        public T Peek()
        {
            return list.Last();
        }
    }
}
