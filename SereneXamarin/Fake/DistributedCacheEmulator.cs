using System;
using Serenity.Abstractions;

namespace SereneXamarin.Mobile.Fake
{
    class DistributedCacheEmulator : IDistributedCache
    {
        public TValue Get<TValue>(string key)
        {
            return default(TValue);
        }

        public long Increment(string key, int amount = 1)
        {
            return amount;
        }

        public void Set<TValue>(string key, TValue value)
        {
            
        }

        public void Set<TValue>(string key, TValue value, TimeSpan expiration)
        {

        }
    }
}