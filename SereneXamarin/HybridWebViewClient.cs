using Android.Content;
using Android.Net;
using Android.OS;
using Android.Webkit;
using Mono.Data.Sqlite;
using Newtonsoft.Json;
using SereneXamarin.Administration.Entities;
using SereneXamarin.Administration.Repositories;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SereneXamarin.Mobile
{
    class HybridWebViewClient : WebViewClient
    {
        Context context;

        public HybridWebViewClient(Context context) : base()
        {
            this.context = context;
        }

        public override bool ShouldOverrideUrlLoading(WebView webView, string url)
        {
            // If the URL is not our own custom scheme, just let the webView load the URL as usual
            var scheme = "fakeajax:services/";

            if (!url.StartsWith(scheme, StringComparison.OrdinalIgnoreCase))
                return false;

            //if (IsNetworkConnected(this.context))
            //    return false;

            var resources = url.Split('?');
            var requestUrl = resources[0];

            var requestJson = System.Web.HttpUtility.UrlDecode(resources[1]);
            string responseJson = string.Empty;
            object responseObj = null;

            using (var connection = GetConnection())
            {
                var mmm = requestUrl.Substring(scheme.Length).Split('/');
                if (mmm.Length > 2)
                {
                    var moduleName = mmm[0];
                    var entityName = mmm[1];
                    var methodName = mmm[2];

                    dynamic repository = Activator.CreateInstance("SereneXamarin.Mobile", $"SereneXamarin.{moduleName}.Repositories.{entityName}Repository").Unwrap();
                    if (methodName.Equals("List", StringComparison.OrdinalIgnoreCase))
                    {
                        ListRequest requestObj;
                        if (requestJson.Equals("undefined"))
                            requestObj = new ListRequest();
                        else
                            requestObj = JsonConvert.DeserializeObject<ListRequest>(requestJson);

                        responseObj = repository.List(connection, requestObj);
                    }
                    else if (methodName.Equals("Create", StringComparison.OrdinalIgnoreCase))
                    {

                        var uow = new UnitOfWork(connection);
                        var req = JsonConvert.DeserializeObject<SaveRequest<RoleRow>>(requestJson);
                        responseObj = repository.Create(uow, req);

                        uow.Commit();

                    }
                    else if (methodName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                    {

                        var uow = new UnitOfWork(connection);
                        var req = JsonConvert.DeserializeObject<SaveRequest<RoleRow>>(requestJson);
                        responseObj = repository.Update(uow, req);

                        uow.Commit();
                    }
                    else if (methodName.Equals("Retrieve", StringComparison.OrdinalIgnoreCase))
                    {
                        var req = JsonConvert.DeserializeObject<RetrieveRequest>(requestJson);
                        responseObj = repository.Retrieve(connection, req);

                    }
                    else if (methodName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                    {

                        var uow = new UnitOfWork(connection);
                        var req = JsonConvert.DeserializeObject<DeleteRequest>(requestJson);
                        responseObj = repository.Delete(uow, req);

                        uow.Commit();
                    }
                    responseJson = JsonConvert.SerializeObject(responseObj);
                    webView.LoadUrl($"javascript: submitFakeAjaxResponse('{requestUrl}', '{responseJson}');");
                }
            }

            return true;
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

        public static Boolean IsNetworkConnected(Context c)
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)c.GetSystemService(Context.ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;

            return isOnline;
        }
    }
}