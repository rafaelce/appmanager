using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aplicacao = Domain.Application;

namespace App.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAppmanagerRepository AppmanagerRepository { get; }
        Task Save();
    }
}
