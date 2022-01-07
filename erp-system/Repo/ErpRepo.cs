using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace erp_system.Repo
{
    public static class ErpRepo
    {
        static string _connectionString = "mongodb+srv://cluster0.0rdkc.mongodb.net/myFirstDatabase?authSource=%24external&authMechanism=MONGODB-X509&retryWrites=true&w=majority";

        static string _certPath = "C:\\X509cert.pfx";

        //public static MongoClient Client { get; set; }

        public static IMongoCollection<BsonDocument> _details;
        public static IMongoCollection<BsonDocument> Details
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
                    _details = client.GetDatabase("erp").GetCollection<BsonDocument>("details");
                }
                return _details;
            }
        }

    }
}
