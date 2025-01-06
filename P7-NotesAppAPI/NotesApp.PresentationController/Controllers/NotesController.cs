using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.Security;
using NotesApp.Application.Excepciones;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Commands.DeleteNote;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.Application.Features.Notes.Queries.GetNoteById;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUserFilterByCategory;
using NotesApp.Domain;
using NotesApp.PresentationController.Utilidades;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/notes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotesController : ControllerBase
    {
        private IMediator mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NotesController(IMediator mediator, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAll()
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            var list = await mediator.Send(new GetNotesPerUserQuery() { IdentityUserId = userId });
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Note>> GetById(int id)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            var note = await mediator.Send(new GetNoteByIdQuery() { IdentityUserId = userId, NoteId = id });
            return Ok(note);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Note>>> GetByCategoryId([FromQuery] int id, [FromQuery] string? name)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            var list = await mediator.Send(new GetNotesPerUserFilterByCategoryNameQuery() { IdentityUserId = userId, CategoryId = id, Name = name });
            return Ok(list);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateNoteCommand createNote)
        {
            createNote.IdentityUserId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(createNote);
            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] UpdateNoteCommand updateNote)
        {
            updateNote.IdentityUserId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(updateNote);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = await GetUserId.Get(_httpContextAccessor, _userManager);
            await mediator.Send(new DeleteNoteCommand { NoteId = id, IdentityUserId = userId});
            return NoContent();
        }
    }
}
