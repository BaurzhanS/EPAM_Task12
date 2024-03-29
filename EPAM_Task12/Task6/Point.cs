﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task6
{
    public class Point : IEquatable<Point>
    {
        private readonly int x;
        private readonly int y;

        public int X => x;
        public int Y => y;

        public Point() : this(0, 0) { }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            if (this.x == other.x && this.y == other.y)
                return true;

            return false;
        }
    }
}

