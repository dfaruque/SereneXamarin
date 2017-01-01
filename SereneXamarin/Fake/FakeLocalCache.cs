using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Serenity.Abstractions;

namespace SereneXamarin.Mobile.Fake
{
    class LocalCache : ILocalCache
    {
        public void Add(string key, object value, TimeSpan expiration)
        {

        }

        public TItem Get<TItem>(string key)
        {
            return default(TItem);
        }

        public object Remove(string key)
        {
            return null;
        }

        public void RemoveAll()
        {

        }
    }
}