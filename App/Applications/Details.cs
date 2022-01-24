using Aplicacao = Domain.Application;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;
using App.Interface;

namespace App.Applications
{
    public class Details
    {
        public class Query : IRequest<Result<Aplicacao>>
        {
            public Guid? Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Aplicacao>>
        {
            private readonly IAppmanagerRepository _appmanagerRepository;
            public Handler(IAppmanagerRepository appmanagerRepository) => _appmanagerRepository = appmanagerRepository;

            public async Task<Result<Aplicacao>> Handle(Query request, CancellationToken cancellationToken)
            {
                var app = await _appmanagerRepository.Get(request.Id);

                return Result<Aplicacao>.Success(app);
            }
           

        }
    }
}