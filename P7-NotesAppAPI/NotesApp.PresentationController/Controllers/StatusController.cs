using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Application.Features.Statuses.Commands.CreateStatus;
using NotesApp.Application.Features.Statuses.Commands.DeleteStatus;
using NotesApp.Application.Features.Statuses.Commands.UpdateStatus;
using NotesApp.Application.Features.Statuses.Queries;
using NotesApp.Domain;
using NotesApp.PresentationController.Controllers.GenericController;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/status")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class StatusController : GenericControllers
    {
        public StatusController(IMediator mediator) : base(mediator)
        { }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Status>>> Get()
        {
            return await GetAllBase<Status, GetStatusQuery>();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromForm] CreateStatusCommand createStatus)
        {
            return await PostBase<CreateStatusCommand>(createStatus);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Post([FromForm] UpdateStatusCommand updateStatus, int id)
        {
            updateStatus.Id = id;
            return await PutBase<UpdateStatusCommand>(updateStatus);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await DeleteBase<DeleteStatusCommand>(new DeleteStatusCommand { Id = id });
        }
    }
}
