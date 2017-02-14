using System.Collections.Generic;

namespace EcmaScriptCompatability.Models
{
    public class FeatureSubCategory
    {
        private ICollection<Feature> features;

        public FeatureSubCategory()
        {
            this.features = new HashSet<Feature>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int FeatureCategoryId { get; set; }

        public virtual FeatureCategory FeatureCategory { get; set; }

        public virtual ICollection<Feature> Features
        {
            get
            {
                return this.features;
            }

            set
            {
                this.features = value;
            }
        }
    }
}
