using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Test7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Test7.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void StringPreorderTest()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };

            var expected = new string[] { "Hello", "Mr", "Jon", "Skeet" };

            var result = treeString.Preorder().ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void StringInorderTest()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };

            var expected = new string[] { "Hello", "Jon", "Mr", "Skeet" };

            var result = treeString.Inorder().ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void StringPostorderTest()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };

            var expected = new string[] { "Jon", "Skeet", "Mr", "Hello" };

            var result = treeString.Postorder().ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void FindByValueTest()
        {
            var treeString = new BinaryTree<string>() { "Hello", "Mr", "Jon", "Skeet" };

            string value = "Jon"; 
            string result = treeString.FindByValue(value).Value;

            Assert.AreEqual(value, result);
        }
    }
}