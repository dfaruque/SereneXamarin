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

            //WebView.SetWebContentsDebuggingEnabled(true);
            //var hybridWebChromeClient = new HybridWebChromeClient(webView.Context);
            //webView.SetWebChromeClient(hybridWebChromeClient);

            // Use subclassed WebViewClient to intercept hybrid native calls
            webView.SetWebViewClient(new HybridWebViewClient(webView.Context));
            DependancyResolve();
            // Render the view from the type generated from RazorView.cshtml
            ////var model = new Model1() { Text = "Text goes here" };
            ////var template = new RazorView() { Model = model };
            ////var page = template.GenerateString();

            // Load the rendered HTML into the view with a base URL 
            // that points to the root of the bundled Assets folder
            webView.LoadUrl("file:///android_asset/RazorView.html");

        }

        private static void DependancyResolve()
        {
            if (!Dependency.HasResolver)
            {
                var container = new MunqContainer();
                Dependency.SetResolver(container);
            }
            var registrar = Dependency.Resolve<IDependencyRegistrar>();
            registrar.RegisterInstance<IAuthorizationService>(new Fake.AuthorizationService());
            registrar.RegisterInstance<IAuthenticationService>(new Fake.AuthenticationService());
            registrar.RegisterInstance<IPermissionService>(new LogicOperatorPermissionService(new Fake.PermissionService()));
            registrar.RegisterInstance<IUserRetrieveService>(new Fake.UserRetrieveService());

            if (Dependency.TryResolve<ILocalCache>() == null)
                registrar.RegisterInstance<ILocalCache>(new Fake.LocalCache());

            if (Dependency.TryResolve<IDistributedCache>() == null)
                registrar.RegisterInstance<IDistributedCache>(new Fake.DistributedCacheEmulator());
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
                WebResourceResponse response = null;
                using (var connection = GetConnection())
                {
                    if (url.Equals("http://Serenity.Mobile/Services/Administration/Role/List", StringComparison.OrdinalIgnoreCase))
                    {
                        var data = new RoleRepository().List(connection,
                            new Serenity.Services.ListRequest { });

                        view.LoadUrl($"javascript: setItemToActiveGrid('{data.Entities.ToJson()}');");

                    }
                    else if (url.Equals("http://Serenity.Mobile/Services/Administration/Role/Create", StringComparison.OrdinalIgnoreCase))
                    {
                        var uow = new UnitOfWork(connection);
                        var c = new RoleRepository().Create(uow,
                            new Serenity.Services.SaveRequest<RoleRow>
                            {
                                Entity = new RoleRow { RoleName = "vbgRolwsxcvbdjfk" }
                            });

                        uow.Commit();
                        view.LoadUrl($"javascript: setItemToActiveGrid('{c.ToJson()}');");


                    }
                    return response;
                }

                return base.ShouldInterceptRequest(view, url);
            }
            public static Stream GenerateStreamFromString(string s)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            #region ISQLite implementation
            public IDbConnection GetConnection()
            {
                var sqliteFilename = "defaultdatabase.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);

                // This is where we copy in the prepopulated database
                Console.WriteLine(path);
                if (!File.Exists(path))
                {
                    var s = this.context.Resources.OpenRawResource(Resource.Raw.defaultdatabase);  // RESOURCE NAME ###

                    // create a write stream
                    FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    // write to the stream
                    ReadWriteStream(s, writeStream);
                }

                var connection = new SqliteConnection($@"data source = {path}");

                // Return the database connection as WrappedConnection
                return new WrappedConnection(connection, new SqliteDialect());
            }
            #endregion

            /// <summary>
            /// helper method to get the database out of /raw/ and into the user filesystem
            /// </summary>
            void ReadWriteStream(Stream readStream, Stream writeStream)
            {
                int Length = 256;
                Byte[] buffer = new Byte[Length];
                int bytesRead = readStream.Read(buffer, 0, Length);
                // write the required bytes
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = readStream.Read(buffer, 0, Length);
                }
                readStream.Close();
                writeStream.Close();
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

            //    //@TargetApi(Build.VERSION_CODES.LOLLIPOP)
            ////@Override

            //public override WebResourceResponse shouldInterceptRequest(WebView view, IWebResourceRequest request)
            //    {
            //        Log.i(TAG, "shouldInterceptRequest path:" + request.getUrl().getPath());
            //        WebResourceResponse returnResponse = null;
            //        if (request.getUrl().getPath().startsWith("/cart"))
            //        { // only interested in /cart requests
            //            returnResponse = super.shouldInterceptRequest(view, request);
            //            Log.i(TAG, "cart AJAX call - doing okRequest");
            //            Request okRequest = new Request.Builder()
            //                    .url(request.getUrl().toString())
            //                    .post(null)
            //                    .build();
            //            try
            //            {
            //                Response okResponse = app.getOkHttpClient().newCall(okRequest).execute();
            //                if (okResponse != null)
            //                {
            //                    int statusCode = okResponse.code();
            //                    String encoding = "UTF-8";
            //                    String mimeType = "application/json";
            //                    String reasonPhrase = "OK";
            //                    Map<String, String> responseHeaders = new HashMap<String, String>();
            //                    if (okResponse.headers() != null)
            //                    {
            //                        if (okResponse.headers().size() > 0)
            //                        {
            //                            for (int i = 0; i < okResponse.headers().size(); i++)
            //                            {
            //                                String key = okResponse.headers().name(i);
            //                                String value = okResponse.headers().value(i);
            //                                responseHeaders.put(key, value);
            //                                if (key.toLowerCase().contains("x-cart-itemcount"))
            //                                {
            //                                    Log.i(TAG, "setting cart item count");
            //                                    app.setCartItemsCount(Integer.parseInt(value));
            //                                }
            //                            }
            //                        }
            //                    }
            //                    InputStream data = new ByteArrayInputStream(okResponse.body().string().getBytes(StandardCharsets.UTF_8));
            //                    Log.i(TAG, "okResponse code:" + okResponse.code());
            //                    returnResponse = new WebResourceResponse(mimeType, encoding, statusCode, reasonPhrase, responseHeaders, data);
            //                }
            //                else
            //                {
            //                    Log.w(TAG, "okResponse fail");
            //                }
            //            }
            //            catch (IOException e)
            //            {
            //                e.printStackTrace();
            //            }
            //        }
            //        return returnResponse;
            //    }
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
}

