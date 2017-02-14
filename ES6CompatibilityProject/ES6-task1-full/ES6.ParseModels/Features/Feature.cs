using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ES6.Models.Features
{
    public class Feature
    {
        public int Id { get; set; }

        [BsonElement("index")]
        public int Index { get; set; }

        [BsonElement("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [NotMapped]
        [MaxLength(300)]
        public string Description { get; set; }

        [NotMapped]
        [MaxLength(300)]
        public string SampleCode { get; set; }

        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

    }
}