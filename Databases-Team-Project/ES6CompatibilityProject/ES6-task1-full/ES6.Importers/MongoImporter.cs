using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Data;
using ES6.Importers.Contracts;
using ES6.Models.Features;
using ES6.Models.Platforms;
using ES6.Readers.Contracts;

namespace ES6.Importers
{
    public class MongoImporter : IMongoImporter
    {
        private IMongoReader mongoReader;

        public MongoImporter(IMongoReader mongoReader)
        {
            this.mongoReader = mongoReader;
        }

        public void ImportData()
        {
            var featuresFromMongo = this.mongoReader.ReadMongoFeatures();
            var platformsFromMongo = this.mongoReader.ReadMongoPlatforms();

            var features = this.MergeFeatures(featuresFromMongo);
            var platforms = this.MergePlatforms(platformsFromMongo);

            this.ImportFeatures(features);
            this.ImportPlatforms(platforms);
        }

        private IEnumerable<Category> MergeFeatures(IEnumerable<Category> featuresFromMongo)
        {
            var features = featuresFromMongo
                .Select(c => new Category()
                {
                    Name = c.Name,
                    Subcategories = c.Subcategories
                                     .Select(sub => new SubCategory()
                                     {
                                         Name = sub.Name,
                                         Features = sub.Features
                                                       .Select(f => new Feature()
                                                       {
                                                           Name = f.Name,
                                                           Index = f.Index,
                                                           Description = f.Description
                                                       })
                                                       .ToList()
                                     })
                                     .ToList()
                });

            return features;
        }

        private IEnumerable<PlatformType> MergePlatforms(IEnumerable<PlatformType> platformsFromMongo)
        {
            var platforms = platformsFromMongo
                .Select(plType => new PlatformType()
                {
                    PlatformTypeName = plType.PlatformTypeName,
                    Platforms = plType.Platforms
                                  .Select(pl => new Platform()
                                  {
                                      Name = pl.Name,
                                      Index = pl.Index
                                  })
                                  .ToList()
                });

            return platforms;
        }

        private void ImportFeatures(IEnumerable<Category> features)
        {
            using (var db = new Es6DbContext())
            {
                var counter = 0;
                foreach (var category in features)
                {
                    db.Categories.Add(category);

                    counter++;
                    if (counter % 100 == 0)
                    {
                        db.SaveChanges();
                    }
                }

                db.SaveChanges();
            }
        }

        private void ImportPlatforms(IEnumerable<PlatformType> platforms)
        {
            using (var db = new Es6DbContext())
            {
                foreach (var platformType in platforms)
                {
                    db.PlatformTypes.Add(platformType);
                }

                db.SaveChanges();
            }
        }
    }
}
