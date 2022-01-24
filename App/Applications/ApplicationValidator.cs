using FluentValidation;
using Aplicacao = Domain.Application;

namespace App.Applications
{
    public class ApplicationValidator : AbstractValidator<Aplicacao>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.PathLocal).NotEmpty();
            RuleFor(x => x.DebuggingMode).NotEmpty();
        }
    }
}