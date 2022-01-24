using Aplicacao = Domain.Application;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Applications
{
    public class List
    {
        public class Query : IRequest<List<Aplicacao>> { }
        public class Handler : IRequestHandler<Query, List<Aplicacao>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context) => _context = context;
            public async Task<List<Aplicacao>> Handle(Query request, CancellationToken cancellationToken)
            => await _context.Applications.ToListAsync();
        }
    }
}