using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackAndQueueWithDynMax;
namespace TestsForTask
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethodForQueue()
        {
            SimpleQueue que = new SimpleQueue();
            que.Enqueue(10);
            que.Enqueue(1);
            que.Enqueue(3);
            que.Enqueue(0);

            Assert.AreEqual(que.CurrMax(), 10);

            que.Enqueue(100);

            Assert.AreEqual(que.CurrMax(), 100);

        }
        [TestMethod]
        public void TestMethodForStack()
        {
            Stack stack = new Stack();
            stack.Push(10);
            stack.Push(9);
            stack.Push(-1);

            Assert.AreEqual(stack.CurrMax(), 10);

            stack.Push(1000);

            Assert.AreEqual(stack.CurrMax(), 1000);

        }
    }
}
