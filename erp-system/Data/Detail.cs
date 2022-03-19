using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace erp_system.Data
{
    public class Detail
    {
        public ObjectId Id { get; set; }

        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("revision")]
        public int Revision { get; set; }

        [BsonElement("drawingNum")]
        public string DrawingNum { get; set; }

        [BsonElement("drawingRevision")]
        public int DrawingRevision { get; set; }
        public bool? IsAssembly { get; set; }
        public bool? IsOwn { get; set; }
        public string[] Bom { get; set; }


    }
    
}
