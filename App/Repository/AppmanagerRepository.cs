using App.Interface;
using Persistence;

using Aplicacao = Domain.Application;

namespace App.Repository
{
    public class AppmanagerRepository : GenericRepository<Aplicacao>, IAppmanagerRepository
    {
        private readonly DataContext _context;

        public AppmanagerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
