using EcmaScriptCompatability.Exporter.Models;
using EcmaScriptCompatability.Models;
using EcmaScriptCompatability.Repositories.Contracts;
using EcmaScriptCompatability.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcmaScriptCompatability.Service
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Feature> featuresRepository;
        private readonly IRepository<Platform> platformRepository;
        private readonly IRepository<Developer> developerRepository;

        public ReportService(
            IUnitOfWork unitOfWork,
            IRepository<Feature> featuresRepository,
            IRepository<Platform> platformRepository,
            IRepository<Developer> developerRepository)
        {
            if (unitOfWork == null)
            {
                throw new NullReferenceException();
            }

            if (featuresRepository == null)
            {
                throw new NullReferenceException();
            }

            this.platformRepository = platformRepository;
            this.featuresRepository = featuresRepository;
            this.developerRepository = developerRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PlatformXmlModel> ExtractPlatformReport()
        {
            var inMemoryPlatform = this.platformRepository.GetAll();
            var inMemoryDeveloper = this.developerRepository.GetAll();
            var inMemoryFeature = this.featuresRepository.GetAll();

            var platform = inMemoryPlatform.Select(x => new PlatformXmlModel
            {
                Name = x.Name,
                Developers = inMemoryDeveloper.Where(y => y.PlatformEmployerId == x.Id).Select(
                   y => new DeveloperXmlModel
                   {
                       Name = y.FirstName,
                       Features = inMemoryFeature.Where(f => f.DeveloperId == y.Id).Select(
                           f => new FeatureXmlModel
                           {
                               Name = f.Name
                           }).ToList()
                   }).ToList()
            }).ToList();

            return platform;
        }
    }
}
