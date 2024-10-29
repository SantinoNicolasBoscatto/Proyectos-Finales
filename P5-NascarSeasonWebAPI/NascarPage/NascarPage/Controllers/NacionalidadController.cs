using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/nacionalidad")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class NacionalidadController : ControllerBase
    {
        private readonly INacionalidadService nacionalidadService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<NacionalidadController> logger;
        private static readonly string contenedor = "nacionalidad";

        public NacionalidadController(INacionalidadService nacionalidadService, IFilesService filesService, IMapper mapper, 
            ILogger<NacionalidadController> logger)
        {
            this.nacionalidadService = nacionalidadService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaNacionalidadDTO>>> Get()
        {
            try
            {
                var list = await nacionalidadService.GetNacionalidades();
                var lectura = mapper.Map<List<LecturaNacionalidadDTO>>(list);
                return Ok(lectura); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }
        [HttpGet("{id:int}", Name = "NacionPorId")]
        public async Task<ActionResult<LecturaNacionalidadDTO>> GetPorId(int id)
        {
            try
            {
                var nacion = await nacionalidadService.GetNacionalidadPorId(id);
                if (nacion == null) return NotFound(new { message = "Nacionalidad No Encontrada" });
                return Ok(mapper.Map<LecturaNacionalidadDTO>(nacion));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaNacionalidadDTO>> Post([FromForm] CrearNacionalidadDTO nacionDTO)
        {
            try
            {
                if (nacionDTO.Bandera == null ) BadRequest(new { message = "Imagen no cargada" });

                var nacion = mapper.Map<Nacionalidad>(nacionDTO);
                nacion.Bandera = await filesService.GuardarImagen(contenedor, nacionDTO.Bandera!);
                await nacionalidadService.AgregarNacionalidad(nacion);
                var lectura = mapper.Map<LecturaNacionalidadDTO>(nacion);
                return CreatedAtRoute("NacionPorId", new { id = nacion.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearNacionalidadDTO nacionDTO, int id)
        {
            try
            {            
                if (!await nacionalidadService.Existe(id)) return BadRequest(new { message = "No existe el auto que desea modificar" });

                var nacionBD = await nacionalidadService.GetNacionalidadPorId(id);
                var banderaRespaldo = nacionBD!.Bandera;
                var idRespaldo = nacionBD!.Id;
                nacionBD = mapper.Map<Nacionalidad>(nacionDTO);
                if (nacionDTO.Bandera is not null)
                    nacionBD.Bandera = await filesService.Editar(nacionBD!.Bandera, contenedor, nacionDTO.Bandera!);
                else
                    nacionBD.Bandera = banderaRespaldo;

                nacionBD.Id = idRespaldo;
                await nacionalidadService.ModificarNacionalidad(nacionBD);
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
                if (!await nacionalidadService.Existe(id)) return BadRequest(new { message = "La nacionalidad a borrar no existe" });
                var ruta = await nacionalidadService.EliminarNacionalidad(id);
                await filesService.Borrar(ruta, contenedor);
                return NoContent();
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, la nacionalidad que quiere borrar tiene pilotos asociados" });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

    }
}
