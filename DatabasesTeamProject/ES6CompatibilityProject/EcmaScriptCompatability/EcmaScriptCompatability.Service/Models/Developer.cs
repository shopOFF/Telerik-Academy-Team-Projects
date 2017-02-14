using System.Collections.Generic;

namespace EcmaScriptCompatability.Service.Models
{
    public class Developer
    {
        private ICollection<Feature> features;

        public Developer()
        {
            this.features = new HashSet<Feature>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PlatformEmployerId { get; set; }

        public virtual Platform PlatformEmployer { get; set; }

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
