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

namespace SereneXamarin.Mobile
{
    [Activity(Label = "SereneXamarin.Mobile", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;

            WebView.SetWebContentsDebuggingEnabled(true);

            var hybridWebChromeClient = new HybridWebChromeClient(webView.Context);
            webView.SetWebChromeClient(hybridWebChromeClient);

            // Use subclassed WebViewClient to intercept hybrid native calls
            webView.SetWebViewClient(new HybridWebViewClient(webView.Context));

            // Render the view from the type generated from RazorView.cshtml
            ////var model = new Model1() { Text = "Text goes here" };
            ////var template = new RazorView() { Model = model };
            ////var page = template.GenerateString();

            // Load the rendered HTML into the view with a base URL 
            // that points to the root of the bundled Assets folder
            webView.LoadUrl("file:///android_asset/RazorView.html");

        }

        private class HybridWebViewClient : WebViewClient
        {
            Context context;

            public HybridWebViewClient(Context context) : base()
            {
                this.context = context;

            }

            public override bool ShouldOverrideUrlLoading(WebView webView, string url)
            {
                // If the URL is not our own custom scheme, just let the webView load the URL as usual
                var scheme = "hybrid:";

                ////if (!url.StartsWith(scheme))
                ////    return false;

                if (IsNetworkConnected(this.context))
                    return false;

                // This handler will treat everything between the protocol and "?"
                // as the method name.  The querystring has all of the parameters.
                var resources = url.Substring(scheme.Length).Split('?');
                var method = resources[0];
                var parameters = System.Web.HttpUtility.ParseQueryString(resources[1]);

                if (method == "UpdateLabel")
                {
                    var textbox = parameters["textbox"];

                    // Add some text to our string here so that we know something
                    // happened on the native part of the round trip.
                    var prepended = string.Format("C# says \"{0}\"", textbox);

                    // Build some javascript using the C#-modified result
                    var js = string.Format("SetLabelText('{0}');", prepended);

                    webView.LoadUrl("javascript:" + js);
                }

                return true;
            }
            //override 
            public override void OnReceivedClientCertRequest(WebView view, ClientCertRequest request)
            {
                base.OnReceivedClientCertRequest(view, request);
             
            }

            public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
            {
                base.OnReceivedError(view, request, error);
            }
            public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
            {
                base.OnReceivedHttpError(view, request, errorResponse);
            }
            public override WebResourceResponse ShouldInterceptRequest(WebView view, string url)
            {
                return base.ShouldInterceptRequest(view, url);
            }
            public override WebResourceResponse ShouldInterceptRequest(WebView view, IWebResourceRequest request)
            {
                if (request.Url.Path != null && request.Url.Path.Contains("Services/Administration/Role"))
                {

                }

                return base.ShouldInterceptRequest(view, request);
            }

            public override void OnFormResubmission(WebView view, Message dontResend, Message resend)
            {
                base.OnFormResubmission(view, dontResend, resend);
            }

            public static Boolean IsNetworkConnected(Context c)
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)c.GetSystemService(Context.ConnectivityService);

                NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
                bool isOnline = (activeConnection != null) && activeConnection.IsConnected;

                return isOnline;
            }
        }

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
                Log.Debug("MyApplication", message + " -- From line "
                     + lineNumber + " of "
                     + sourceID);

            }
            public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
            {
                Log.Debug("MyApplication", consoleMessage.Message() + " -- From line "
                                     + consoleMessage.LineNumber() + " of "
                                     + consoleMessage.SourceId());
                
                return base.OnConsoleMessage(consoleMessage);
            }

        }
    }
}

