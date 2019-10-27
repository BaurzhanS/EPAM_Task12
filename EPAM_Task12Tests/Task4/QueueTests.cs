using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task4.Tests
{
    [TestClass()]
    public class QueueTests
    {
        [TestMethod()]
        public void MakeQueueTest()
        {
            var expected = new int[] { 7, 10, 8, 9, 4, 6, 8, 1, 1 };

            var result = new Queue<int>();

            foreach (int item in expected)
                result.Enqueue(item);

            Assert.IsTrue(expected.SequenceEqual(result.GetArrayOfQueueElements()));
        }

        [TestMethod()]
        public void DequeueTest()
        {
            var array = new int[] { 12, 2, 4, 6, 8, 3 };

            var expected = new int[] { 4, 6, 8, 3 };
            var queue = new Queue<int>();

            foreach (int item in array)
                queue.Enqueue(item);

            queue.Dequeue();
            queue.Dequeue();

            var result = queue.GetArrayOfQueueElements();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], expected[i]);
            }
        }

        [TestMethod()]
        public void EnqueueTest()
        {
            var array = new int[] { 12, 2, 4, 6, 8, 3 };

            var expected = new int[] { 12, 2, 4, 6, 8, 3, 34, 35 };
            var queue = new Queue<int>();

            foreach (int item in array)
                queue.Enqueue(item);

            queue.Enqueue(34);
            queue.Enqueue(35);

            var result = queue.GetArrayOfQueueElements();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], expected[i]);
            }
        }
    }
}