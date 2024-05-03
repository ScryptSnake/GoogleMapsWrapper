using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Types
{
    internal class LockSafeHashList<TItem,THash>
    {
        private readonly object locker = new();

        private IList<TItem> itemList = new List<TItem>();
        public IReadOnlyList<TItem> Items { get => itemList.AsReadOnly(); }

        
        
        private HashSet<THash> hashSet = new HashSet<THash>();

        //ignore warning - MUST ensure hash value is never null when added to object
        //alternative is to use where THash : struct, but want to allow ref types for hash key. 
        public IReadOnlyDictionary<THash,TItem> Dictionary => hashDict.AsReadOnly();    
        private Dictionary<THash, TItem> hashDict = new Dictionary<THash, TItem>();


        private LockSafeHashList()
        {

        }


        public void Add(TItem item, THash hash)
        {
            if (hash == null) { throw new ArgumentNullException(nameof(hash)); }    

            lock (this.locker)
            {
                hashSet.Add(hash);
                itemList.Add(item);
                hashDict.Add(hash, item);   
            }
        }

        public void AddOrReplace(TItem item, THash hash)
        {
            lock (this.locker)
            {
                if (this.Contains(hash))
                {
                    Replace(hash, item); //this methods calls two locks
                }
                else
                {
                    Add(item,hash); //this method also locks
                }

            }
        }


        public void Remove(THash hash)
        {
            if (hash == null) { throw new ArgumentNullException(nameof(hash)); }
            lock (this.locker)
            {
                var item = this.GetItem(hash);
                hashSet.Remove(hash);
                itemList.Remove(item);
                hashDict.Remove(hash);
            }
        }

        public void Replace(THash hash, TItem item)
        {
            lock (this.locker)
            {
                Remove(hash);
                Add(item,hash);
            }
        }

        public TItem GetItem(THash hash) => this.hashDict[hash];

        public bool Contains(THash hash) => hashSet.Contains(hash);


    }
}
