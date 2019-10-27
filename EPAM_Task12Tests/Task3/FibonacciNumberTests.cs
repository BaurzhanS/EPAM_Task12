using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task3.Tests
{
    [TestClass()]
    public class FibonacciNumberTests
    {
        [TestMethod()]
        public void GetSequenceTest()
        {
            List<int> expected = new List<int> {0,1,1,2,3,5,8,13,21,34,55 };
            List<int> result = FibonacciNumber.GetSequence(10).ToList();
            CollectionAssert.AreEqual(expected, result);
        }
    }
}