using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task1
{
    public static class Comparator
    {
        public static readonly Func<int, int, int> comparatorForInt = delegate (int x, int y)
        {
            if (x == y)
                return 0;

            if (x > y)
                return 1;

            return -1;
        };
    }
}
