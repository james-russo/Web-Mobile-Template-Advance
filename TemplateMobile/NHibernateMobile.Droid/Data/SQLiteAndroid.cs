using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Demo.Configuration;

using Xamarin.Forms;
using DemoMobile.Droid.Data;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SqLiteAndroid))]
namespace DemoMobile.Droid.Data
{
    public class SqLiteAndroid : ISqlLite
    {
        private const String SqliteFileName = "Shamrock.db3";

        public SqLiteAndroid() { }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            string docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(docsPath, SqliteFileName);

            var conn = new SQLite.SQLiteAsyncConnection(path);

            return conn;
        }

        public SQLiteConnection GetConnection()
        {
            string docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(docsPath, SqliteFileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}