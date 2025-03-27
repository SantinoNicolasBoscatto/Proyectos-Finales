
using AutoMapper;
using Grpc.Core;
using MediatR;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.DeleteOrder;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.UpdateAutor;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAllAutors;
using PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAutorById;

namespace PruebaMicroservicios.Autor.Presentation.Services
{
    public class AutorService : Autor.AutorBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public AutorService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public override async Task<GetAllAutorResponse> GetAllAutor(GetAllAutorRequest request, ServerCallContext context)
        {
            var autors = await mediator.Send(new GetAllAutorsQuery());
            var response = new GetAllAutorResponse();
            var serverResponse = new ServerResponse();

            if(autors != null && autors.Any())
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Autors found";
                response.Data.AddRange(mapper.Map<List<AutorResponse>>(autors));
            }
            else serverResponse.Message = "Autors not found";

            response.ServerResponse = serverResponse;
            return response;
        }

        public override async Task<GetAutorByIdResponse> GetAutor(GetAutorByIdRequest request, ServerCallContext context)
        {
            var autor = await mediator.Send(new GetAutorByIdQuery { Id = request.Id});
            var response = new GetAutorByIdResponse();
            var serverResponse = new ServerResponse();

            if (autor != null)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Autor found";
                response.Data = mapper.Map<AutorResponse>(autor);
            }
            else serverResponse.Message = "Autor not found";

            response.ServerResponse = serverResponse;
            return response;
        }

        public override async Task<CreateAutorResponse> CreateAutor(CreateAutorRequest request, ServerCallContext context)
        {
            var createAutor = mapper.Map<CreateAutorCommand>(request);
            var status = await mediator.Send(createAutor);
            var response = new CreateAutorResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var autorDTO = await mediator.Send(new GetAutorByIdQuery { Id = createAutor.Id.ToString() });
                response.Data = mapper.Map<AutorResponse>(autorDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Autor created";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Autor not created";
            }
            response.Response = serverResponse;
            return response;
        }

        public override async Task<UpdateAutorResponse> UpdateAutor(UpdateAutorRequest request, ServerCallContext context)
        {
            var updateAutor = mapper.Map<UpdateAutorCommand>(request);
            var status = await mediator.Send(updateAutor);
            var response = new UpdateAutorResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var autorDTO = await mediator.Send(new GetAutorByIdQuery { Id = updateAutor.Id });
                response.Data = mapper.Map<AutorResponse>(autorDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Autor updated";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Autor not updated";
            }
            response.Response = serverResponse;
            return response;
        }

        public override async Task<DeleteAutorResponse> DeleteAutor(DeleteAutorRequest request, ServerCallContext context)
        {
            var deleteCommand = new DeleteAutorCommand { AutorId = request.Id };
            var status = await mediator.Send(deleteCommand);
            var response = new DeleteAutorResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Autor deleted";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Autor not deleted";
            }
            response.ServerResponse = serverResponse;
            return response;
        }
    }
}
