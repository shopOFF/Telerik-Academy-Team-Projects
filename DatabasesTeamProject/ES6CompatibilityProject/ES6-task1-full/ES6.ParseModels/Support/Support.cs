using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Models.Features;
using ES6.Models.Platforms;

namespace ES6.ParseModels.Support
{
    public class Support
    {
        public int Id { get; set; }

        public string IsSupported { get; set; }

        public int FeatureId { get; set; }

        [NotMapped]
        public virtual Feature Feature { get; set; }

        public int PlatformId { get; set; }

        [NotMapped]
        public virtual Platform Platform { get; set; }
    }
}
