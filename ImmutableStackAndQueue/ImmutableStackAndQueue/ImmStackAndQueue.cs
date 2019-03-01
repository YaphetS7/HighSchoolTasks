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
    public class ImmQueue<T>
    {
        Queue<T> que = new Queue<T>();
        public ImmQueue<T> Enqueue(T value)
        {
            que.Enqueue(value);
            return this;
        }
        public ImmQueue<T> Dequeue()
        {
            que.Dequeue();
            return this;
        }
        public T First()
        {
            return que.First();
        }
        
    }
    public class ImmStack<T>
    {
        Stack<T> stack = new Stack<T>();
        public ImmStack<T> Push(T value)
        {
            stack.Push(value);
            return this;
        }
        public ImmStack<T> Pop()
        {
            stack.Pop();
            return this;
        }
        public T Peek()
        {
            return stack.Peek();
        }
    }
}
