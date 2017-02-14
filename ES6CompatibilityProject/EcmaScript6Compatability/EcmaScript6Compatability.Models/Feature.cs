using System.ComponentModel.DataAnnotations;

namespace EcmaScript6Compatability.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int FeatureSubCategoryId { get; set; }

        public virtual FeatureSubCategory FeatureSubCategory { get; set; }
    }
}
