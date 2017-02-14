using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcmaScript6Compatability.Models
{
    public class Platform
    {
        private ICollection<FeatureCategory> featureCategories;
        private ICollection<Developer> developers;


        public Platform()
        {
            this.featureCategories = new HashSet<FeatureCategory>();
            this.developers = new HashSet<Developer>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int PlatformTypeId { get; set; }

        public virtual PlatformType PlatformType { get; set; }

        public virtual ICollection<Developer> Developers
        {
            get
            {
                return this.developers;
            }
            set
            {
                this.developers = value;
            }
        }

        public virtual ICollection<FeatureCategory> FeatureCategories
        {
            get
            {
                return this.featureCategories;
            }
            set
            {
                this.featureCategories = value;
            }
        }
    }
}
