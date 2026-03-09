using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRedis.Storage
{
    public class InMemoryStore
    {
        private Dictionary<string, string> store;

        public InMemoryStore()
        {
            store = new Dictionary<string, string>();
        }

        public void Set(string key, string value)
        {
            store[key] = value;
        }

        public string Get(string key)
        {
            if (store.TryGetValue(key, out var value))
            {
                return value;
            }
            else
                return null;
        }


        public bool Delete(string key)
        {
            return store.Remove(key);
        }

    }
}
