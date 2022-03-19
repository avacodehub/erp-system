using erp_system.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace erp_system.Repo
{
    public static class ErpRepo
    {
        static string _connectionString = "mongodb+srv://cluster0.0rdkc.mongodb.net/myFirstDatabase?authSource=%24external&authMechanism=MONGODB-X509&retryWrites=true&w=majority";

        static string _certPath = "C:\\X509cert.pfx";

        //public static MongoClient Client { get; set; }

        private static IMongoCollection<Detail> _details;
        public static IMongoCollection<Detail> Details
        {
            get
            {
                if (_details == null)
                {
                    var settings = MongoClientSettings.FromConnectionString(_connectionString);
                    var cert = new X509Certificate2(_certPath, "cert343");
                    settings.SslSettings = new SslSettings
                    {
                        ClientCertificates = new List<X509Certificate>() { cert }
                    };
                    var client = new MongoClient(settings);
                    _details = client.GetDatabase("erp").GetCollection<Detail>("details");
                }
                return _details;
            }
        }

        public static void CreateDetail(Detail detail)
        {
            Details.InsertOne(detail);
        }
    }
}
