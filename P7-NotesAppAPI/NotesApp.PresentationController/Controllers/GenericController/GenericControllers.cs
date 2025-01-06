using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Excepciones;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Queries.GetNotesPerUser;
using NotesApp.PresentationController.Utilidades;
using System.Linq;

namespace NotesApp.PresentationController.Controllers.GenericController
{
    public class GenericControllers : ControllerBase
    {
        private IMediator mediator;
        public GenericControllers(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<ActionResult<List<TDTO>>> GetAllBase<TDTO, TQuery>()
        where TQuery : class, IRequest<List<TDTO>>, new()
        {
            try
            {
                var list = await mediator.Send(new TQuery());
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Un error inesperado ocurrio");
            }
        }

        protected async Task<ActionResult> PostBase<TCommand>([FromForm] TCommand create)
            where TCommand : class, IRequest, new()
        {
            try
            {
                await mediator.Send(create);
                return Created();
            }
            catch (GenericException)
            {
                return BadRequest("Error al crear el registro, revise la informacion ingresada");
            }
            catch (Exception)
            {
                return BadRequest("Un error inesperado ocurrio");
            }
        }

        protected async Task<ActionResult> PutBase<TCommand>([FromForm] TCommand create)
            where TCommand : class, IRequest, new()
        {
            try
            {
                await mediator.Send(create);
                return NoContent();
            }
            catch (GenericException)
            {
                return BadRequest("El elemento a modificar no existe o no tiene permiso a el");
            }
            catch (Exception)
            {
                return BadRequest("Un error inesperado ocurrio");
            }
        }

        protected async Task<ActionResult> DeleteBase<TCommand>(TCommand command)
            where TCommand : class, IRequest, new()
        {
            try
            {
                await mediator.Send(command);
                return NoContent();
            }
            catch (GenericException)
            {
                return BadRequest("El elemento a borrar no se encuentra");
            }
            catch (Exception)
            {
                return BadRequest("Un error inesperado ocurrio");
            }
        }

    }
}
