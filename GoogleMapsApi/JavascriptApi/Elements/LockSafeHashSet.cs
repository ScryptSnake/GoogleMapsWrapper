using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.JavascriptApi.Elements
{
    /// <summary>
    /// A HashSet that is modified within a thread lock mechanism. 
    /// </summary>
    /// <typeparam name="T"> The type of object to store in the hash set. Null ref types are rejected during Add method.
    /// Note: the type should have an IEqualityComparer<typeparamref name="T"/> for this hashset to determine equality.
    /// The equality comparer used for a given type can be checked with: EqualityComparer<typeparamref name="T"/>.Default</typeparam>
    public class LockSafeHashSet<T>
    {
        private readonly object locker = new();
        public IReadOnlyList<T> Items { get => hashSet.ToList().AsReadOnly(); }

        private HashSet<T> hashSet;

        private bool ignoreExistsException = false;

        public LockSafeHashSet(IEqualityComparer<T> comparer, bool ignoreExistsException = false)
        {
            this.ignoreExistsException = ignoreExistsException;
            hashSet = new HashSet<T>(comparer);
        }

        /// <summary>
        /// Add item. 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="throwIfExists"> Throw exception if item exists. Else ignore quietly.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Add(T item, bool throwIfExists = true)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            lock (locker)
            {
                var result = hashSet.Add(item);
                if (throwIfExists ==true && result == false)
                {
                    throw new InvalidOperationException("Item already exists in set.");
                }
            }
        }

        /// <summary>
        /// Add or replace item. 
        /// </summary>
        /// <param name="item"></param>
        public void AddOrReplace(T item)
        {
            lock (locker)
            {
                if (hashSet.Contains(item))
                    Replace(item); //this methods calls two locks
                else
                    Add(item); //this method also locks
            }
        }
        /// <summary>
        /// Removes item from set.
        /// </summary>
        /// <param name="item"> Ignored if doesn't exist.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Remove(T item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            lock (locker)
            {
                hashSet.Remove(item); //ignore if item doesn't exists
            }
        }

        /// <summary>
        /// Replace an item in the set with a new item. Existing item is determined by the comparer. 
        /// </summary>
        /// <param name="item"></param>
        public void Replace(T item)
        {
            //already inside locks...
            Remove(item);
            Add(item);
        }

        public bool Contains(T item) => hashSet.Contains(item);

        public void Clear() { hashSet.Clear(); }
    }
}
