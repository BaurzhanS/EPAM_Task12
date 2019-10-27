using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task5.Tests
{
    [TestClass()]
    public class Stack_Tests
    {
        [TestMethod()]
        public void StackPushTest()
        {
            var expected = new string[] {"my", "life", "is", "good" };

            Stack_<string> result = new Stack_<string>(4);
            foreach (string item in expected)
                result.push(item);

            Assert.IsTrue(expected.SequenceEqual(result.GetAllStackElements()));
        }

        [TestMethod()]
        public void StackPopTest()
        {
            var array = new string[] { "my", "life", "is", "good" };

            Stack_<string> result = new Stack_<string>(4);
            foreach (string item in array)
                result.push(item);

            string res = result.pop();
            string expected = "good";

            Assert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void StackPeepTest()
        {
            var array = new string[] { "my", "life", "is", "good" };

            Stack_<string> result = new Stack_<string>(4);
            foreach (string item in array)
                result.push(item);

            string res = result.peep(2);
            string expected = "is";

            Assert.AreEqual(expected, res);
        }
    }
}