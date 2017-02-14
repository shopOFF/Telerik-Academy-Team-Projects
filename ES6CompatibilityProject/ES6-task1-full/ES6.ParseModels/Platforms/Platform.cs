using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ES6.Models.Platforms
{
    public class Platform
    {
        public int Id { get; set; }

        [BsonElement("index")]
        public int Index { get; set; }

        [BsonElement("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        [NotMapped]
        public string Description { get; set; }

        public int PlatformTypeId { get; set; }

        public virtual PlatformType PlatformType { get; set; }

    }
}
