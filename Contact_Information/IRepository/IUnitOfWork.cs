using Contact_Information.Model;
using System;
using System.Threading.Tasks;
using static Contact_Information.IRepository.IGenericRepository;

namespace Contact_Information.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Contacts> Contacts { get; }
        IGenericRepository<Countries> Countries { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Location> Locations { get; }

        Task Save();
    }
}
