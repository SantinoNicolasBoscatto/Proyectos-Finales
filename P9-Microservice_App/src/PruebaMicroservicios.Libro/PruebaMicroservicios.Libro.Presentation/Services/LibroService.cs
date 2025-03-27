using AutoMapper;
using Grpc.Core;
using MediatR;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.CreateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.DeleteLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.UpdateLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetAllLibros;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByAutorLibro;
using PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro;

namespace PruebaMicroservicios.Libro.Presentation.Services
{
    public class LibroService : Libro.LibroBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public LibroService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async override Task<GetAllLibroResponse> GetAllLibro(GetAllLibroRequest request, ServerCallContext context)
        {
            var libros = await mediator.Send(new GetAllLibrosQuery());
            var response = new GetAllLibroResponse();
            var serverResponse = new ServerResponse();

            if (libros != null && libros.Any())
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libros found";
                response.Data.AddRange(mapper.Map<List<LibroResponse>>(libros));
            }
            else serverResponse.Message = "Libros not found";

            response.ServerResponse = serverResponse;
            return response;
        }

        public async override Task<GetLibroByIdResponse> GetLibro(GetLibroByIdRequest request, ServerCallContext context)
        {
            var libro = await mediator.Send(new GetByIdLibroQuery { Id = request.Id });
            var response = new GetLibroByIdResponse();
            var serverResponse = new ServerResponse();

            if (libro != null)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libro found";
                response.Data = mapper.Map<LibroResponse>(libro);
            }
            else serverResponse.Message = "Libro not found";

            response.ServerResponse = serverResponse;
            return response;
        }

        public async override Task<GetAllLibroByAutorResponse> GetAllLibroByAutor(GetAllLibroByAutorRequest request, ServerCallContext context)
        {
            var listLibro = await mediator.Send(new GetByAutorLibroQuery { AutorId = request.AutorId });
            var response = new GetAllLibroByAutorResponse();
            var serverResponse = new ServerResponse();

            if (listLibro != null)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libro Autor found";
                response.Data.AddRange(mapper.Map<List<LibroResponse>>(listLibro));
            }
            else serverResponse.Message = "Libro Autor not found";

            response.ServerResponse = serverResponse;
            return response;
        }

        public async override Task<CreateLibroResponse> CreateLibro(CreateLibroRequest request, ServerCallContext context)
        {
            var createLibro = mapper.Map<CreateLibroCommand>(request);
            var status = await mediator.Send(createLibro);
            var response = new CreateLibroResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var libroDTO = await mediator.Send(new GetByIdLibroQuery { Id = createLibro.Id!.ToString() });
                response.Data = mapper.Map<LibroResponse>(libroDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libro created";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Libro not created";
            }
            response.Response = serverResponse;
            return response;
        }

        public async override Task<UpdateLibroResponse> UpdateLibro(UpdateLibroRequest request, ServerCallContext context)
        {
            var updateLibro = mapper.Map<UpdateLibroCommand>(request);
            var status = await mediator.Send(updateLibro);
            var response = new UpdateLibroResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var libroDTO = await mediator.Send(new GetByIdLibroQuery { Id = updateLibro.Id });
                response.Data = mapper.Map<LibroResponse>(libroDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libro updated";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Libro not updated";
            }
            response.Response = serverResponse;
            return response;
        }

        public async override Task<DeleteLibroResponse> DeleteLibro(DeleteLibroRequest request, ServerCallContext context)
        {
            var deleteCommand = new DeleteLibroCommand { Id = request.Id };
            var status = await mediator.Send(deleteCommand);
            var response = new DeleteLibroResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Libro deleted";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Libro not deleted";
            }
            response.ServerResponse = serverResponse;
            return response;
        }
    }
}
