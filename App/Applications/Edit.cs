using Aplicacao = Domain.Application;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace App.Applications
{
    public class Edit
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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _context.Applications.FindAsync(request.Application.Id);
                _mapper.Map(request.Application, application);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}