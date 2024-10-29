using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using System;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/pilotos")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PilotosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPilotoService pilotoService;
        private readonly IFilesService filesService;
        private readonly ILogger<PilotosController> logger;
        private static readonly string contenedor = "pilotos";
        private static readonly string contenedorAutos = "autos";

        public PilotosController(IMapper mapper, IPilotoService pilotoService, IFilesService filesService, ILogger<PilotosController> logger)
        {
            this.mapper = mapper;
            this.pilotoService = pilotoService;
            this.filesService = filesService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaPilotoDTO>>> Get()
        {
            try
            {
                var list = await pilotoService.GetPilotos();
                return Ok(mapper.Map<List<LecturaPilotoDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("campeones")]
        public async Task<ActionResult<List<LecturaPilotoDTO>>> GetCampeones()
        {
            try
            {
                var list = await pilotoService.GetCampeones();
                return Ok(mapper.Map<List<LecturaPilotoDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("carless")]
        public async Task<ActionResult<List<LecturaPilotoDTO>>> GetCarLess()
        {
            try
            {
                var list = await pilotoService.GetCarless();
                return Ok(mapper.Map<List<LecturaPilotoDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("{id:int}", Name = "PilotoPorId")]
        public async Task<ActionResult<LecturaPilotoDTO>> GetPorId(int id)
        {
            try
            {
                var piloto = await pilotoService.GetPilotoPorId(id);
                if (piloto is null) return NotFound(new { message = "El Piloto no existe" });
                return Ok(mapper.Map<LecturaPilotoDTO>(piloto));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("prevnext/{id:int}", Name = "prevNext")]
        public async Task<ActionResult<(int?, int?)>> GetPreviousNext(int id)
        {
            try
            {
                return pilotoService.PreviousNext(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaPilotoDTO>> Post([FromForm] CrearPilotoDTO pilotoDTO)
        {
            if (pilotoDTO.FotoPiloto == null) return BadRequest(new { message = "Porfavor Cargue una foto" });
            var piloto = mapper.Map<Piloto>(pilotoDTO);
            try
            {
                piloto.FotoPiloto = await filesService.GuardarImagen(contenedor, pilotoDTO.FotoPiloto);
                var id = await pilotoService.PostPilotos(piloto);
                var lectura = mapper.Map<LecturaPilotoDTO>(piloto);
                return CreatedAtRoute("PilotoPorId", new { id = id }, lectura);
            }
            catch (Exception ex)
            {
                await filesService.Borrar(piloto.FotoPiloto, contenedor);
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearPilotoDTO pilotoDTO, int id)
        {
            try
            {
                if (!await pilotoService.Existe(id)) return NotFound(new { message = "El piloto a actualizar no existe" });

                var pilotoBD = await pilotoService.GetPilotoPorId(id);
                pilotoBD!.Nacionalidad = null!;
                pilotoBD = mapper.Map(pilotoDTO, pilotoBD);
                if (pilotoDTO.FotoPiloto is not null)
                    pilotoBD!.FotoPiloto = await filesService.Editar(pilotoBD.FotoPiloto, contenedor, pilotoDTO.FotoPiloto);
                await pilotoService.ModificarPiloto(pilotoBD!);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<PatchPilotoDTO> patchDocument, int id)
        {
            try
            {
                if (patchDocument is null) return BadRequest(new { message = "Error en el documento Patch" });

                var pilotoBD = await pilotoService.GetPilotoPorId(id);
                if (pilotoBD is null) return NotFound();

                var pilotoDTO = mapper.Map<PatchPilotoDTO>(pilotoBD);
                patchDocument.ApplyTo(pilotoDTO, ModelState);

                var esValido = TryValidateModel(pilotoDTO);
                if (!esValido) return BadRequest(new { message = "Ingreso Datos erroneos al Piloto" });

                var piloto = mapper.Map(pilotoDTO, pilotoBD);
                await pilotoService.ModificarPiloto(piloto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LecturaPilotoDTO>> Delete(int id)
        {
            try
            {
                var existe = await pilotoService.Existe(id);
                if (!existe) return BadRequest(new { message = "Piloto a borrar no existe" });
                var ruta = await pilotoService.EliminarPiloto(id);
                await filesService.Borrar(ruta.Item1, contenedor);
                await filesService.Borrar(ruta.Item2, contenedorAutos);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }
    }
}
