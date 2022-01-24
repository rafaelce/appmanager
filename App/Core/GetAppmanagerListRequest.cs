using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using Aplicacao = Domain.Application;

namespace App.Core
{
    public class GetAppmanagerListRequest : IRequest<List<Aplicacao>>
 {
    }
}
