using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Applications;
using Aplicacao = Domain.Application;
using MediatR;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : BaseApiController
    {
        public ApplicationsController(IMediator mediator)
        => _mediator = mediator;
        
        [HttpGet]
        public async Task<ActionResult<List<Aplicacao>>> GetApplications()
        => await Mediator.Send(new List.Query());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetApplication(Guid? id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(Aplicacao aplicacao)
        => Ok(await Mediator.Send(new Create.Command { Application = aplicacao }));

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditApplication(Guid id, Aplicacao aplicacao)
        {
            aplicacao.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Application = aplicacao }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(Guid? id)
        => Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
}