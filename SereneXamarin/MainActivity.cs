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

            WebView.SetWebContentsDebuggingEnabled(true);
            var hybridWebChromeClient = new HybridWebChromeClient(webView.Context);
            webView.SetWebChromeClient(hybridWebChromeClient);

            // Use subclassed WebViewClient to intercept hybrid native calls
            webView.SetWebViewClient(new HybridWebViewClient(webView.Context));

            DependancyResolve();
            // Render the view from the type generated from RazorView.cshtml
            ////var model = new Model1() { Text = "Text goes here" };
            ////var template = new RazorView() { Model = model };
            ////var page = template.GenerateString();

            // add javascript interface
            webView.AddJavascriptInterface(new AjaxHandler(this), "ajaxHandler");

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


    }
}

