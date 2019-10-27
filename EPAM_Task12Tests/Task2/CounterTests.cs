using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace EPAM_Task12.Task2.Tests
{
    [TestClass()]
    public class CounterTests
    {
        [TestMethod()]
        public void CounterTest()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"text.txt");

            Counter counter = new Counter(path);
            int result = counter.WordCounter.Count;
            int expected = 77;
            Assert.AreEqual(expected, result);
        }
    }
}