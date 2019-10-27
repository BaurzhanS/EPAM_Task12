using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task1.Tests
{
    [TestClass()]
    public class BinaryTests
    {
        [TestMethod()]
        public void BinarySearchTest()
        {
            int[] array = new int[] { 5, 11, 7, 9, 4, 2, 0, 3, 1 };
            int element = 2;
            Array.Sort(array);
            int result = array.BinarySearch(2, Comparator.comparatorForInt);
            Assert.AreEqual(element, result);
        }
    }
}