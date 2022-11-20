using Contact_Information.Data;
using Contact_Information.IRepository;
using Contact_Information.Model;
using System;
using System.Threading.Tasks;
using static Contact_Information.IRepository.IGenericRepository;

namespace Contact_Information.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactContext _context;

        private IGenericRepository<Contacts> _contacts;
        private IGenericRepository<Countries> _countries;
        private IGenericRepository<User> _users;
        private IGenericRepository<Location> _locations;

        public UnitOfWork(ContactContext context)
        {
            _context = context;
        }

        public IGenericRepository<Contacts> Contacts => _contacts ??= new GenericRepository<Contacts>(_context);
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<Location> Locations => _locations ??= new GenericRepository<Location>(_context);

        public IGenericRepository<Countries> Countries => _countries ??= new GenericRepository<Countries>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }



        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
