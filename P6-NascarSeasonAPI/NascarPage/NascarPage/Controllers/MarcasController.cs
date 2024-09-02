using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService marcaService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<MarcasController> logger;
        private static readonly string contenedorMarcas = "marcas";
        private static readonly string contenedorAutos = "autos";

        public MarcasController(IMarcaService marcaService, IFilesService filesService, IMapper mapper, ILogger<MarcasController> logger)
        {
            this.marcaService = marcaService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaMarcaDTO>>> Get()
        {
            try
            {
                var list = await marcaService.GetMarcas();
                var lectura = mapper.Map<List<LecturaMarcaDTO>>(list);
                return Ok(lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpGet("{id:int}", Name = "MarcaPorId")]
        public async Task<ActionResult<LecturaMarcaDTO>> GetPorId(int id)
        {
            try
            {
                var marca = await marcaService.GetMarcaPorId(id);
                if (marca == null) return NotFound("No se encontro esa marca");
                var lectura = mapper.Map<LecturaMarcaDTO>(marca);
                return Ok(lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearMarcaDTO marcaDTO)
        {
            try
            {
                if (marcaDTO.Foto == null) BadRequest("Imagen no cargada");

                var marca = mapper.Map<Marca>(marcaDTO);
                marca.Foto = await filesService.GuardarImagen(contenedorMarcas, marcaDTO.Foto!);
                await marcaService.AgregarMarca(marca);
                var lectura = mapper.Map<LecturaMarcaDTO>(marca);
                return CreatedAtRoute("MarcaPorId", new { id = marca.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearMarcaDTO marcaDTO, int id)
        {
            try
            {
                if (!await marcaService.Existe(id)) return BadRequest("No existe la marca que desea modificar");

                var marcaBD = await marcaService.GetMarcaPorId(id);
                marcaBD = mapper.Map<Marca>(marcaDTO);
                if (marcaDTO.Foto != null)
                    marcaBD.Foto = await filesService.Editar(marcaBD!.Foto, contenedorMarcas, marcaDTO.Foto);

                await marcaService.ActulizarMarca(marcaBD);
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
                if (!await marcaService.Existe(id)) return BadRequest("No existe la marca que desea eliminar");

                var imgs = await marcaService.EliminarMarca(id);
                await filesService.Borrar(imgs.Item1, contenedorMarcas);
                foreach (var item in imgs.Item2)
                {
                    await filesService.Borrar(item, contenedorAutos);
                }
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
