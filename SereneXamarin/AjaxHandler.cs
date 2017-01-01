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
using Android.Util;

namespace SereneXamarin.Mobile
{
    // our JavascriptInterface
    public class AjaxHandler : Java.Lang.Object
    {

        private static String TAG = "AjaxHandler";
        private Context context;

        public AjaxHandler(Context context)
        {
            this.context = context;
        }

        public void ajaxBegin()
        {
            Log.Warn(TAG, "AJAX Begin");
            Toast.MakeText(context, "AJAX Begin", ToastLength.Short).Show();
        }

        public void ajaxDone()
        {
            Log.Warn(TAG, "AJAX Done");
            Toast.MakeText(context, "AJAX Done", ToastLength.Short).Show();
        }
    }
}