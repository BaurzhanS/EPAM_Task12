using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPAM_Task12.Task6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task6.Tests
{
    [TestClass()]
    public class SetTests
    {
        private Set<Point> firstSet = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5) });
        private Set<Point> secondSet = new Set<Point>(new Point[] { new Point(3, 3), new Point(5, 5), new Point(9, 9), new Point(10, 10) });

        [TestMethod]
        public void AddUniqueElementToSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5), new Point(100, 200) });
            var newPoint = new Point(100, 200);

            firstSet.Add(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void AddExistingElementToSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(5, 5) });
            var newPoint = new Point(5, 5);

            firstSet.Add(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void DeleteExistingElementFromSet()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) });
            var newPoint = new Point(5, 5);

            firstSet.Delete(newPoint);

            Assert.IsTrue(firstSet.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void IntersectionOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(3, 3), new Point(5, 5) });

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.Intersect(secondSet)));
        }

        [TestMethod]
        public void DifferenceOfTwoSets()
        {
            var expectedResult = new Set<Point>(new Point[] { new Point(1, 1), new Point(2, 2) });

            Assert.IsTrue(expectedResult.SequenceEqual(firstSet.Difference(secondSet)));
        }
    }
}