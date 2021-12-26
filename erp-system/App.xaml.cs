using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MongoDB.Driver;
using MongoDB.Bson;
using erp_system.Tools;

namespace erp_system
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        public static string _mongostring = "mongodb://localhost:27017";
        public MongoClient DB { get; set; }

        public App()
        {
            DB = new MongoClient(_mongostring);
            var _generator = new IdGenerator();
            //var _pass = ""
            //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://avacode:<password>@cluster0.0rdkc.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            //var client = new MongoClient(settings);
            //var database = client.GetDatabase("test");

            MessageBox.Show((_generator.CreateId(new List<int> { 1, 2, 4, 5}).ToString()));
        }

    }
}
