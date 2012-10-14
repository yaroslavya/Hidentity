using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Hidentity.Configuration
{
    /// <summary>
    /// Provides access to set of types we are going to substitute. Also sets which properties we are going to substitute.
    /// </summary>
    public class SubstitutablesRegistry
    {
        #region Singleton

        /// <summary>
        /// Making a constructor private to make a singleton.
        /// </summary>
        private SubstitutablesRegistry() { }

        private static SubstitutablesRegistry _item;

        public static SubstitutablesRegistry Instance 
        {
            get
            {
                if (_item == null)
                    _item = new SubstitutablesRegistry();

                return _item;
            }
        }

        #endregion

        private Hashtable _items = new Hashtable();
        
        public void Add(Substitutable item)
        {
            var items = Find(item.TypeGuid);
            if (items != null)
                items.Add(item);
            else
            {
                var newItems = new List<Substitutable>();
                newItems.Add(item);

                _items.Add(item.TypeGuid, newItems);
            }
        }

        public List<Substitutable> Find(string typeGuid)
        {
            if(_items.ContainsKey(typeGuid))
                return _items[typeGuid] as List<Substitutable>;

            return null;
        }
    }
}
