using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Test7
{
    public sealed class BinaryTree<T> : ICollection<T>
    {
        private Node head;

        private int count;

        private IComparer<T> comparator;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Count can't be less then zero.");

                count = value;
            }
        }

        public IComparer<T> Comparator
        {
            get
            {
                return comparator;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                comparator = value;
            }
        }

        public BinaryTree() : this(Comparer<T>.Default) { }

        public BinaryTree(IComparer<T> comparator)
        {
            head = null;
            Count = 0;
            this.comparator = comparator;
        }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (head == null)
            {
                head = new Node(value);
                Count++;
                return;
            }

            if (!Contains(value))
            {
                AddTo(head, value);
                Count++;
            }
        }

        private void AddTo(Node node, T value)
        {
            if (comparator.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node(value);
                else
                    AddTo(node.Right, value);
            }
        }

        public Node FindByValue(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (head == null)
                throw new InvalidOperationException("Tree is empty!");

            return Find(head, value);
        }

        private Node Find(Node node, T value)
        {
            if (node == null)
                return null;

            if (comparator.Compare(node.Value, value) == 0)
                return node;

            if (comparator.Compare(node.Value, value) > 0)
                return Find(node.Left, value);

            return Find(node.Right, value);
        }

        public IEnumerable<T> Preorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            Node current = head;

            while (true)
            {
                if (current != null)
                {
                    roots.Push(current);
                    yield return current.Value;
                    current = current.Left;
                }
                else
                {
                    if (roots.Any())
                        current = roots.Pop().Right;
                    else
                        break;
                }
            }
        }

        public IEnumerable<T> Inorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            var current = head;

            bool isDone = false;

            while (!isDone)
            {
                if (!ReferenceEquals(current, null))
                {
                    roots.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (!roots.Any())
                    {
                        isDone = true;
                    }
                    else
                    {
                        current = roots.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                }
            }
        }

        public IEnumerable<T> Postorder() => DoPostOrder(head);

        private IEnumerable<T> DoPostOrder(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in DoPostOrder(node.Left))
                {
                    yield return leftNode;
                }
            }

            if (node.Right != null)
            {
                foreach (var rightNode in DoPostOrder(node.Right))
                {
                    yield return rightNode;
                }
            }

            yield return node.Value;
        }

        bool ICollection<T>.IsReadOnly => false;

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (FindByValue(item) != null)
                return true;

            return false;
        }

        public void CopyTo(T[] destinationArray, int startIndex)
        {
            if (ReferenceEquals(destinationArray, null))
                throw new ArgumentNullException(nameof(destinationArray));

            if (startIndex < 0)
                throw new ArgumentException("Start index can't be less than zero.");

            if (startIndex > destinationArray.Length)
                throw new ArgumentException("Start index can't be greater than lenght of destination array.");

            if ((destinationArray.Length - 1 - startIndex) < Count)
                throw new ArgumentException("Number of tree's elements is greater then given array range.");

            foreach (T item in Inorder())
            {
                destinationArray[startIndex] = item;
                startIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public class Node
        {
            public Node Left { get; set; }
           
            public Node Right { get; set; }

            public T Value
            {
                get
                {
                    return value;
                }
                private set
                {
                    if (value == null)
                        throw new ArgumentException("Value of tree's node can't be null.");

                    this.value = value;
                }
            }

            public Node() : this(default(T)) { }

            public Node(T value)
            {
                Value = value;
            }

            public override string ToString()
            {
                if (Left == null)
                {
                    if (Right == null)
                        return $"Value: {value}, left: empty, right: empty.";

                    return $"Value: {value}, left: empty, right: {Right.Value}";
                }

                if (Right == null)
                    return $"Value: {value}, left: {Left.value}, right: empty.";

                return $"Value: {value}, left: {Left.value}, right: {Right.value}.";
            }
            private T value;
        }
    }
}
