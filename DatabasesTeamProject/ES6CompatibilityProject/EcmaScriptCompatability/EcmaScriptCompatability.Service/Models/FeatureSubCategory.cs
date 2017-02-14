using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScriptCompatability.Service.Models
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
