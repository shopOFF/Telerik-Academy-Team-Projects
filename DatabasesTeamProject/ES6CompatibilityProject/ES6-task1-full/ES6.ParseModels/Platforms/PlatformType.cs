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
    public class PlatformType
    {
        private ICollection<Platform> platforms;

        public PlatformType()
        {
            this.Platforms = new HashSet<Platform>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [NotMapped]
        public string MongoId { get; set; }

        [Key]
        public int Id { get; set; }

        [BsonElement("platformType")]
        [MaxLength(50)]
        public string PlatformTypeName { get; set; }

        [BsonElement("platforms")]
        public virtual ICollection<Platform> Platforms
        {
            get { return this.platforms; }
            set { this.platforms = value; }
        }
    }
}
