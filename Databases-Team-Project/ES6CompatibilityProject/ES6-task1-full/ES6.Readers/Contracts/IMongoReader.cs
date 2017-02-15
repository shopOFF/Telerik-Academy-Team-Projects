using System.Collections.Generic;

using ES6.Models.Features;
using ES6.Models.Platforms;

namespace ES6.Readers.Contracts
{
    public interface IMongoReader
    {
        IEnumerable<Category> ReadMongoFeatures();

        IEnumerable<PlatformType> ReadMongoPlatforms();
    }
}
