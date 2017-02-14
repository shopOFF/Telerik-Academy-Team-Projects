using EcmaScript6Compatability.Data;
using EcmaScript6Compatability.Data.Contracts;
using EcmaScript6Compatability.Models;

namespace EcmaScript6Compatability
{
    class Program
    {
        static void Main(string[] args)
        {
            IEcmaScript6DbContext context = new EcmaScript6DbContext();

            var platformTypeRepository = new EFRepository<PlatformType>(context);

            var platformType = new PlatformType()
            {
                Name = "First platform1",

            };

            platformTypeRepository.Add(platformType);
            platformTypeRepository.SaveChanges();
        }
    }
}
