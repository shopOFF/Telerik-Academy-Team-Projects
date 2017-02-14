using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ES6.Models.Features
{
    public class Category
    {
        private ICollection<SubCategory> subcategories;

        public Category()
        {
            this.Subcategories = new HashSet<SubCategory>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [NotMapped]
        public string MongoId { get; set; }

        [Key]
        public int Id { get; set; }

        [BsonElement("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [BsonElement("subcategories")]
        public virtual ICollection<SubCategory> Subcategories
        {
            get { return this.subcategories; }
            set { this.subcategories = value; }
        }
    }
}
