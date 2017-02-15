namespace EcmaScriptCompatability.Models
{
    public class Feature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FeatureSubCategoryId { get; set; }

        public virtual FeatureSubCategory FeatureSubCategory { get; set; }

        public virtual int DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
