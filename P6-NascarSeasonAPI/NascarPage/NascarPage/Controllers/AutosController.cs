using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    
    [ApiController]
    [Route("api/autos")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AutosController : ControllerBase
    {
        private readonly IAutoService autoService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<AutosController> logger;
        private static readonly string contenedor = "autos";

        public AutosController(IAutoService autoService, IFilesService filesService, IMapper mapper, ILogger<AutosController> logger)
        {
            this.autoService = autoService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaAutoDTO>>> Get()
        {
            try
            {
                var list = await autoService.GetAutos();
                return Ok(mapper.Map<List<LecturaAutoDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpGet("{id:int}", Name = "AutoPorId")]
        public async Task<ActionResult<LecturaAutoDTO>> GetPorId(int id)
        {
            try
            {
                var auto = await autoService.GetAutoId(id);
                if (auto == null) return NotFound("Auto No Encontrado");
                return Ok(mapper.Map<LecturaAutoDTO>(auto));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaAutoDTO>> Post([FromForm] CrearAutoDTO autoDTO)
        {
            try
            {
                if (autoDTO.Foto == null) return BadRequest("Imagen no cargada");
                if (autoDTO.PilotoId != null && !await autoService.ExistePiloto(autoDTO.PilotoId)) return BadRequest("No existe el piloto");
                if (!await autoService.ExisteMarca(autoDTO.MarcaId)) return BadRequest("Esta Marca no existe en la Base de Datos");


                var auto = mapper.Map<Auto>(autoDTO);
                auto.Foto = await filesService.GuardarImagen(contenedor, autoDTO.Foto!);
                await autoService.AgregarAuto(auto);
                var lectura = mapper.Map<LecturaAutoDTO>(auto);
                return CreatedAtRoute("AutoPorId", new { id = auto.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearAutoDTO autoDTO, int id)
        {
            try
            {
                if (!await autoService.Existe(id)) return BadRequest("No existe el auto que desea modificar");
                if (autoDTO.PilotoId != null && !await autoService.ExistePiloto(autoDTO.PilotoId)) return BadRequest($"El Piloto de id {id} no existe en la Base de Datos");
                if (!await autoService.ExisteMarca(autoDTO.MarcaId)) return BadRequest("Esta Marca no existe en la Base de Datos");

                var autoBD = await autoService.GetAutoId(id);
                autoBD = mapper.Map(autoDTO, autoBD);
                if (autoDTO.Foto is not null) autoBD!.Foto = await filesService.Editar(autoBD.Foto, contenedor, autoDTO.Foto!);

                await autoService.ModificarAuto(autoBD!);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<PatchAutoDTO> patchDocument, int id)
        {
            try
            {
                if (patchDocument is null) return BadRequest("Error en el documento Patch");

                var autoBD = await autoService.GetAutoId(id);
                if (autoBD is null) return NotFound();

                var autoDTO = mapper.Map<PatchAutoDTO>(autoBD);
                patchDocument.ApplyTo(autoDTO, ModelState);

                var esValido = TryValidateModel(autoDTO);
                if (!esValido) return BadRequest("Ingreso Datos erroneos al Piloto");

                var auto = mapper.Map(autoDTO, autoBD);
                await autoService.ModificarAuto(auto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existe = await autoService.Existe(id);
                if (!existe) return BadRequest("Piloto a borrar no existe");
                var ruta = await autoService.EliminarAuto(id);
                await filesService.Borrar(ruta, contenedor);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }
    }
}
