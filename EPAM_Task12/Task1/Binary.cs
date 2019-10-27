using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task1
{
    public static class Binary
    {
        public static int BinarySearch<T>(this T[] array, T element, Func<T, T, int> comparator)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentException("Array can't be empty.");

            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middleIndex = left + (right - left) / 2;

                if (array[middleIndex].Equals(element))
                    return middleIndex;

                if (comparator(element, array[middleIndex]) == 1)
                    left = middleIndex + 1;
                else right = middleIndex - 1;
            }

            return -1;
        }
    }
}
