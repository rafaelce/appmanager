
using App.Interface;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Threading.Tasks;

using Aplicacao = Domain.Application;

namespace App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IAppmanagerRepository _appmanagerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
    
        public IAppmanagerRepository AppmanagerRepository =>
            _appmanagerRepository ??= new AppmanagerRepository(_context);
     
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
