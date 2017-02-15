using System.Linq;

namespace EcmaScript6Compatability.Data.Contracts
{
    public interface IRepository<Tentity>
    {
        IQueryable<Tentity> All();

        Tentity FindById(int id);

        void Add(Tentity entity);

        void Update(Tentity entity);

        void Remove(Tentity entity);

        void SaveChanges();
    }
}
