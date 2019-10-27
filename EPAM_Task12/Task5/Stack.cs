using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task5
{
    public class Stack_<T>
    {
        int capacity;
        T[] stack;
        int top;

        public Stack_(int MaxElements)
        {
            capacity = MaxElements;

            stack = new T[capacity];
        }

        public int push(T Element)
        {           
            if (top == capacity)
            {
                return -1;
            }
            else
            {
                stack[top] = Element;
                top = top + 1;
            }
            return 0;
        }

        public T pop()
        {
            T RemovedElement;

            T temp = default(T);

            if (!(top <= 0))
            {
                top = top - 1;
                RemovedElement = stack[top];

                return RemovedElement;
            }
            return temp;
        }

        public T peep(int position)
        {
            T temp = default(T);

            if (position < capacity && position >= 0)
            {
                return stack[position];
            }
            return temp;
        }

        public T[] GetAllStackElements()
        {
            T[] Elements = new T[top];

            Array.Copy(stack, 0, Elements, 0, top);

            return Elements;
        }
    }
}
