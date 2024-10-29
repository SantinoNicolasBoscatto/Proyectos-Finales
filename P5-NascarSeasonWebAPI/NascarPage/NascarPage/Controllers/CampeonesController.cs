using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/campeones")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CampeonesController : ControllerBase
    {
        private readonly ICampeonService campeonService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<CampeonesController> logger;
        private static readonly string contenedor = "campeones";

        public CampeonesController(ICampeonService campeonService, IFilesService filesService, IMapper mapper, ILogger<CampeonesController> logger)
        {
            this.campeonService = campeonService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaCampeonDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                var list = await campeonService.GetCampeones(paginacionDTO);
                return Ok(mapper.Map<List<LecturaCampeonDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("{id:int}", Name = "CampeonPorId")]
        public async Task<ActionResult<LecturaCampeonDTO>> GetPorId(int id)
        {
            try
            {
                var champ = await campeonService.GetCampeonId(id);
                if (champ == null) return NotFound(new { message = "Campeon No Encontrado" });
                return Ok(mapper.Map<LecturaCampeonDTO>(champ));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("year/{ChampYear:int}", Name = "CampeonPorYear")]
        public async Task<ActionResult<LecturaCampeonDTO>> GetPorYear(int ChampYear)
        {
            try
            {
                var champ = await campeonService.GetCampeonYear(ChampYear);
                if (champ == null) return NotFound(new { message = "Campeon No Encontrado" });
                return Ok(mapper.Map<LecturaCampeonDTO>(champ));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaCampeonDTO>> Post([FromForm] CrearCampeonDTO campeonDTO)
        {
            try
            {
                if (campeonDTO.AutoCampeon == null) return BadRequest(new { message = "Imagen no cargada" });
                if (!await campeonService.ExistePiloto(campeonDTO.PilotoId)) return BadRequest(new { message = "No existe el piloto" });
                if (!await campeonService.EsCampeon(campeonDTO.PilotoId)) return BadRequest(new { message = "El piloto cargado no es Campeón" });

                var campeon = mapper.Map<Campeon>(campeonDTO);
                campeon.AutoCampeon = await filesService.GuardarImagen(contenedor, campeonDTO.AutoCampeon!);
                await campeonService.AgregarCampeon(campeon);
                var lectura = mapper.Map<LecturaCampeonDTO>(campeon);
                return CreatedAtRoute("CampeonPorId", new { id = campeon.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearCampeonDTO campeonDTO, int id)
        {
            try
            {
                if (!await campeonService.Existe(id)) return BadRequest(new { message = "No existe el Campeon que desea modificar" });
                if (!await campeonService.ExistePiloto(campeonDTO.PilotoId)) return BadRequest(new { message = $"El Piloto de id {id} no existe en la Base de Datos" });
                if (!await campeonService.EsCampeon(campeonDTO.PilotoId)) return BadRequest(new { message = "El Piloto no es campeon o ya fue registrado" });

                var campeonBD = await campeonService.GetCampeonId(id);
                var idRespaldo = campeonBD!.Id;
                var fotoRespaldo = campeonBD.AutoCampeon;
                campeonBD = mapper.Map<Campeon>(campeonDTO);
                if (campeonDTO.AutoCampeon is not null)
                    campeonBD.AutoCampeon = await filesService.Editar(campeonBD!.AutoCampeon, contenedor, campeonDTO.AutoCampeon!);
                else
                    campeonBD.AutoCampeon = fotoRespaldo;

                campeonBD.Id = idRespaldo;
                await campeonService.ModificarCampeon(campeonBD);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<PatchCampeonDTO> patchDocument, int id)
        {
            try
            {
                if (patchDocument is null) return BadRequest(new { message = "Error en el documento Patch" });

                var campeonBD = await campeonService.GetCampeonId(id);
                if (campeonBD is null) return NotFound();

                var campeonDTO = mapper.Map<PatchCampeonDTO>(campeonBD);
                patchDocument.ApplyTo(campeonDTO, ModelState);

                var esValido = TryValidateModel(campeonDTO);
                if (!esValido) return BadRequest(new { message = "Ingreso Datos erroneos del Campeon" });

                var campeon = mapper.Map(campeonDTO, campeonBD);
                await campeonService.ModificarCampeon(campeon);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!await campeonService.Existe(id)) return BadRequest(new { message = "Este campeon no existe" });
                var ruta = await campeonService.EliminarCampeon(id);
                await filesService.Borrar(ruta, contenedor);
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
