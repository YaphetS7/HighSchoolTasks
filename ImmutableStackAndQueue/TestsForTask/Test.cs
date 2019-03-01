using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImmutableStackAndQueue;
namespace TestsForTask
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethodForStack()
        {
            ImmStack<int> stack = new ImmStack<int>();
            stack = stack.Push(10).Push(12).Push(10).Pop();
            Assert.AreEqual(stack.Peek(), 12);
        }
        [TestMethod]
        public void TestMethodForQueue()
        {
            ImmQueue<int> que = new ImmQueue<int>();
            que = que.Enqueue(10).Enqueue(7).Enqueue(31).Dequeue().Dequeue().Dequeue().Enqueue(300);
            Assert.AreEqual(que.First(), 300);
        }
    }

   
}
