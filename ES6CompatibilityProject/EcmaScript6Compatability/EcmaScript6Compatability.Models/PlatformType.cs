using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcmaScript6Compatability.Models
{
    public class PlatformType
    {
        private ICollection<Platform> platforms;

        public PlatformType()
        {
            this.platforms = new HashSet<Platform>();
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Platform> Platforms
        {
            get
            {
                return this.platforms;
            }
            set
            {
                this.platforms = value;
            }
        }
    }
}

