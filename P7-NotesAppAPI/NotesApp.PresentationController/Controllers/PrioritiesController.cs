using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Application.Features.Priorities.Commands.CreatePriority;
using NotesApp.Application.Features.Priorities.Commands.DeletePriority;
using NotesApp.Application.Features.Priorities.Commands.UpdatePriority;
using NotesApp.Application.Features.Priorities.Queries;
using NotesApp.Domain;
using NotesApp.PresentationController.Controllers.GenericController;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/priorities")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class PrioritiesController : GenericControllers
    {
        public PrioritiesController(IMediator mediator) : base(mediator)
        {}

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Priority>>> Get()
        {
            return await GetAllBase<Priority, GetPrioritiesQuery>();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreatePriorityCommand create)
        {
            return await PostBase<CreatePriorityCommand>(create);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Post([FromForm] UpdatePriorityCommand update, int id)
        {
            update.Id = id;
            return await PutBase<UpdatePriorityCommand>(update);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await DeleteBase<DeletePriorityCommand>(new DeletePriorityCommand { Id = id });
        }
    }
}
