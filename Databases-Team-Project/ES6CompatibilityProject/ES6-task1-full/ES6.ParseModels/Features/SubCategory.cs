using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ES6.Models.Features
{
    public class SubCategory
    {
        private ICollection<Feature> features;

        public SubCategory()
        {
            this.Features = new HashSet<Feature>();
        }

        public int Id { get; set; }

        [BsonElement("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [BsonElement("features")]
        public virtual ICollection<Feature> Features
        {
            get { return this.features; }
            set { this.features = value; }
        }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}