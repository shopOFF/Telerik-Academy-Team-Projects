using System.Collections.Generic;

namespace EcmaScriptCompatability.Models
{
    public class PlatformType
    {
        private ICollection<Platform> platforms;

        public PlatformType()
        {
            this.platforms = new HashSet<Platform>();
        }

        public int Id { get; set; }

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
