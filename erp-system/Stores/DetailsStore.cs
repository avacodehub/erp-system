using erp_system.MVVM.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace erp_system.Stores
{
    public static class DetailsStore
    {
        static string _connectionString = "mongodb+srv://cluster0.g7w4t.mongodb.net/myFirstDatabase?authSource=%24external&authMechanism=MONGODB-X509&retryWrites=true&w=majority";

        static string _certPath = "C:\\X509cert.pfx";

        private static IMongoCollection<Detail> _details;
        public static IMongoCollection<Detail> Details
        {
            get
            {
                if (_details == null)
                {
                    var settings = MongoClientSettings.FromConnectionString(_connectionString);
                    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                    var cert = new X509Certificate2(_certPath, "q1w2e3");
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

        public static Detail CreateDetail(Detail detail)
        {
            Details.InsertOne(detail);
            return detail;
        }

    }


}
