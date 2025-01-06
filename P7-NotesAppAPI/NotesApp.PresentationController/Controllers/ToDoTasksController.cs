using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Commands.DeleteNote;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask;
using NotesApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;
using NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;
using NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskById;
using NotesApp.Application.Features.ToDoTasks.Queries.GetToDoTaskPerUserNote;
using NotesApp.Domain;
using NotesApp.PresentationController.Utilidades;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/notes/todotask")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ToDoTasksController : ControllerBase
    {
        private IMediator mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ToDoTasksController(IMediator mediator, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{noteId:int}")]
        public async Task<ActionResult<List<ToDoTask>>> GetAllPerNote(int noteId)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            var getter = new GetToDoTasksPerUserNoteQuery
            {
                NoteId = noteId,
                IdentityUserId = userId,
                Priority = true, 
                Asc = false, 
                Status = false,
            };
            var list = await mediator.Send(getter);
            return Ok(list);
        }

        [HttpGet("task/{id:int}")]
        public async Task<ActionResult<ToDoTask>> GetTaskById(int id)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            var getter = new GetToDoTaskByIdQuery{Id = id, IdentityUserId = userId};
            var toDo = await mediator.Send(getter);
            return Ok(toDo);
        }

        [HttpPost("{noteId:int}")]
        public async Task<ActionResult> Post([FromForm] CreateToDoTaskCommand createToDo)
        {
            createToDo.IdentityUserId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(createToDo);
            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] UpdateToDoTaskCommand updateToDo)
        {
            updateToDo.IdentityUserId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(updateToDo);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(new DeleteToDoTaskCommand { IdentityUserId = userId, ToDoTaskId = id });
            return NoContent();
        }
    }
}
