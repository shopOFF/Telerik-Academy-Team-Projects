using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcmaScript6Compatability.Models
{
    public class Developer
    {
        private ICollection<Feature> features;

        public Developer()
        {
            this.features = new HashSet<Feature>();
        }

        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        public int PlatformEmployerId { get; set; }

        [Required]
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
