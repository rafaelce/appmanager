using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Aplicacao = Domain.Application;

namespace Domain.Interfaces
{
    public interface IApplicationService
    {
        public Aplicacao Create(Aplicacao Aplicacao);
        public void Delete(Guid id);
        public Aplicacao Details(Guid id);
        public IEnumerable<Aplicacao> List();
    }
}