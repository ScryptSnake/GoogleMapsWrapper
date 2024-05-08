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

        public void Add(T item, bool throwIfExists = true)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            lock (locker)
            {
                if (hashSet.Contains(item) && throwIfExists == true)
                    throw new InvalidOperationException("Item already exists");
                hashSet.Add(item); //item is ignored, add returns false if item exists and ignoreExistsException is true.
            }
        }
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
        public void Remove(T item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            lock (locker)
            {
                hashSet.Remove(item); //ignore if item doesn't exists
            }
        }

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
