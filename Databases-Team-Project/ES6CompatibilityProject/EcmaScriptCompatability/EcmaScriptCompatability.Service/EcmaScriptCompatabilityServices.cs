using System;
using EcmaScriptCompatability.Service.Contracts;
using EcmaScriptCompatability.Models;
using System.Collections.Generic;
using EcmaScriptCompatability.Repositories.Contracts;

namespace EcmaScriptCompatability.Service
{
    public class EcmaScriptCompatabilityServices : IEcmaScriptCompatabilityServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Developer> developersRepository;
        private readonly IRepository<PlatformType> platformTypesRepository;
        private readonly IRepository<Platform> platformRepository;

        public EcmaScriptCompatabilityServices(
            IUnitOfWork unitOfWork,
            IRepository<Developer> developersRepository,
            IRepository<PlatformType> platformTypesRepository,
            IRepository<Platform> platformRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            if (developersRepository == null)
            {
                throw new ArgumentNullException();
            }

            if (platformTypesRepository == null)
            {
                throw new ArgumentNullException();

            }

            if (platformRepository == null)
            {
                throw new ArgumentNullException();

            }

            this.unitOfWork = unitOfWork;
            this.developersRepository = developersRepository;
            this.platformRepository = platformRepository;
            this.platformTypesRepository = platformTypesRepository;
        }

        //How to instant new class
        public void CreatePlatformType(string platformTypeName)
        {
            var platformType = new PlatformType()
            {
                Name = platformTypeName
            };

            using (this.unitOfWork)
            {
                this.platformTypesRepository.Add(platformType);

                unitOfWork.Commit();
            }
        }

        public void CreatePlatform(string platformName)
        {
            var platform = new Platform()
            {
                Name = platformName,
                PlatformTypeId = this.platformTypesRepository.GetById(1).Id
            };

            using (this.unitOfWork)
            {
                this.platformRepository.Add(platform);

                unitOfWork.Commit();
            }
        }

        public IEnumerable<Platform> FindPlatformFromSPecificType(string platformType)
        {
            //       var platforms = this.platformTypesRepository.GetAll(x => x.Name == platformType, null,  (x, Platform) => x.Platforms);
            throw new NotImplementedException();
         //   return platforms;
        }
    }
}
