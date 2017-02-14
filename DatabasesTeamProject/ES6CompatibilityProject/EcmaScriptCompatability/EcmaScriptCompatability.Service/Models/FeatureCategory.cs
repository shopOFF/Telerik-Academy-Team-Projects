using System.Collections.Generic;

namespace EcmaScriptCompatability.Service.Models
{
    public class FeatureCategory
    {
        private ICollection<FeatureSubCategory> featureSubCategories;

        public FeatureCategory()
        {
            this.featureSubCategories = new HashSet<FeatureSubCategory>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }

        public virtual ICollection<FeatureSubCategory> FeatureSubCategories
        {
            get
            {
                return this.featureSubCategories;
            }
            set
            {
                this.featureSubCategories = value;
            }
        }
    }
}
