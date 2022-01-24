using Aplicacao = Domain.Application;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence;

namespace App.Applications
{
    public class Create
    {
        public class Command : IRequest
        {
            public Aplicacao Application { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Application).SetValidator(new ApplicationValidator());
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context) => _context = context;
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Applications.Add(request.Application);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}