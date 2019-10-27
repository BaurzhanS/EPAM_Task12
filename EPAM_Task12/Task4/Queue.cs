using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task4
{
    public class Queue<T>
    {
        private T[] array;

        private int indexOfLastElement;

        private int indexOfFirstElement;

        public bool IsEmpty => indexOfFirstElement > indexOfLastElement || (indexOfFirstElement == -1 && indexOfLastElement == -1);
        
        public int Count => indexOfLastElement - indexOfFirstElement + 1;
      
        public Queue()
        {
            array = new T[10];
            indexOfLastElement = -1;
            indexOfFirstElement = -1;
        }
      
        public void Enqueue(T value)
        {
            if (indexOfLastElement == array.Length - 1)
            {
                T[] bufferArr = new T[array.Length];

                for (int i = 0; i < array.Length - 1; i++)
                    bufferArr[i] = array[i];

                array = new T[2 * array.Length];

                for (int i = 0; i < bufferArr.Length - 1; i++)
                    array[i] = bufferArr[i];
            }

            if (IsEmpty)
                indexOfFirstElement = 0;

            indexOfLastElement++;
            array[indexOfLastElement] = value;
        }

        public T Dequeue()
        {
            if (!IsEmpty)
            {
                T result = array[indexOfFirstElement];
                array[indexOfFirstElement] = default(T);
                indexOfFirstElement++;
                return result;
            }
            else throw new InvalidOperationException("Queue is empty!");
        }

        public T Peek()
        {
            if (!IsEmpty)
                return array[indexOfFirstElement];
            throw new InvalidOperationException("Queue is empty!");
        }
      
        public T[] GetArrayOfQueueElements()
        {
            T[] arrayOfStackElements = new T[Count];

            for (int i = indexOfFirstElement, j = 0; i <= indexOfLastElement; i++, j++)
                arrayOfStackElements[j] = array[i];

            return arrayOfStackElements;
        }
      
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public CustomIterator GetEnumerator() => new CustomIterator(this);

        public struct CustomIterator
        {
            private readonly Queue<T> collection;
            private int currentIndex;

            internal CustomIterator(Queue<T> collection)
            {
                this.currentIndex = -1;
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count)
                        throw new InvalidOperationException();
                    return collection[currentIndex];
                }
            }

            public void Reset() => currentIndex = collection.indexOfFirstElement;

            public bool MoveNext() => ++currentIndex < collection.Count;
        }
    }
}
