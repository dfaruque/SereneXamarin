using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;
using SereneXamarin.Mobile.Views;
using SereneXamarin.Mobile.Models;
using Android.Util;
using Android.Net;
using SereneXamarin.Administration.Repositories;
using SereneXamarin.Administration.Entities;
using Serenity.Data;
using System.IO;
using Serenity;
using Mono.Data.Sqlite;
using System.Data;
using Serenity.Abstractions;
using Serenity.Web;

namespace SereneXamarin.Mobile
{
    class HybridWebChromeClient : WebChromeClient
    {
        Context context;

        public HybridWebChromeClient(Context context) : base()
        {
            this.context = context;

        }

        public override bool OnJsAlert(WebView view, string url, string message, JsResult result)
        {
            var alertDialogBuilder = new AlertDialog.Builder(context)
                .SetMessage(message)
                .SetCancelable(false)
                .SetPositiveButton("Ok", (sender, args) =>
                {
                    result.Confirm();
                });

            alertDialogBuilder.Create().Show();

            return true;
        }

        public override bool OnJsConfirm(WebView view, string url, string message, JsResult result)
        {
            var alertDialogBuilder = new AlertDialog.Builder(context)
                .SetMessage(message)
                .SetCancelable(false)
                .SetPositiveButton("Ok", (sender, args) =>
                {
                    result.Confirm();
                })
                .SetNegativeButton("Cancel", (sender, args) =>
                {
                    result.Cancel();
                });

            alertDialogBuilder.Create().Show();

            return true;
        }
        public override void OnConsoleMessage(string message, int lineNumber, string sourceID)
        {
            Android.Util.Log.Debug("MyApplication", message + " -- From line "
                 + lineNumber + " of "
                 + sourceID);

        }
        public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
        {
            Android.Util.Log.Debug("MyApplication", consoleMessage.Message() + " -- From line "
                                 + consoleMessage.LineNumber() + " of "
                                 + consoleMessage.SourceId());

            return base.OnConsoleMessage(consoleMessage);
        }

    }

}