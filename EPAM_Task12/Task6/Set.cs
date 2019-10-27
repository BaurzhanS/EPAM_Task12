using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task6
{
    public class Set<T> : IEnumerable<T> where T : class, IEquatable<T>
    {
        public T[] ToArray() => collection.ToArray();

        private readonly List<T> collection;

        public int Count => collection.Count;
       
        public Set() : this(new List<T>()) { }

        public Set(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException(nameof(collection));

            this.collection = new List<T>();

            foreach (T item in collection)
                Add(item);
        }
       
        public void Add(T insertItem)
        {
            if (ReferenceEquals(insertItem, null))
                throw new ArgumentNullException(nameof(insertItem));

            if (!collection.Contains(insertItem))
                collection.Add(insertItem);
        }

        public void Delete(T deletedItem)
        {
            if (ReferenceEquals(deletedItem, null))
                throw new ArgumentNullException(nameof(deletedItem));

            if (!collection.Contains(deletedItem))
                throw new ArgumentException("Elemet which must be deleted not found");

            collection.Remove(deletedItem);
        }

        public Set<T> Intersect(Set<T> otherSet)
        {
            if (ReferenceEquals(otherSet, null))
                throw new ArgumentNullException(nameof(otherSet));

            return new Set<T>((this.Union(otherSet)).Difference((this.Difference(otherSet)).Union(otherSet.Difference(this))));
        }

        public static Set<T> Intersect(Set<T> firstSet, Set<T> secondSet)
        {
            if (ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if (ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(secondSet));

            if (ReferenceEquals(firstSet, secondSet))
                return new Set<T>(firstSet);

            return firstSet.Intersect(secondSet);
        }

        public Set<T> Difference(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            return new Set<T>(this.collection.Where(item => !other.collection.Contains(item)).ToList());
        }

        public static Set<T> Difference(Set<T> firstSet, Set<T> secondSet)
        {
            if (ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if (ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            return firstSet.Difference(secondSet);
        }

        public Set<T> Union(Set<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var result = new List<T>(this.collection);

            foreach (T item in other.collection)
                if (!result.Contains(item))
                    result.Add(item);

            return new Set<T>(result);
        }

        public static Set<T> Union(Set<T> firstSet, Set<T> secondSet)
        {
            if (ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if (ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(secondSet));

            return firstSet.Union(secondSet);
        }

        public Set<T> SymmetricDifference(Set<T> otherSet)
        {
            if (ReferenceEquals(otherSet, null))
                throw new ArgumentNullException(nameof(otherSet));

            return new Set<T>((this.Union(otherSet)).Difference(this.Intersect(otherSet)));
        }

        public static Set<T> SymmetricDifference(Set<T> firstSet, Set<T> secondSet)
        {
            if (ReferenceEquals(firstSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            if (ReferenceEquals(secondSet, null))
                throw new ArgumentNullException(nameof(firstSet));

            return firstSet.SymmetricDifference(secondSet);
        }
      
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)collection).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

      
    }
}
