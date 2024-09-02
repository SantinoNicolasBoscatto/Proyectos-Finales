using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/galeria")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GaleriaController : ControllerBase
    {
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly IGaleriaService galeriaService;
        private readonly ILogger<GaleriaController> logger;
        private readonly static string contenedor = "galeria";

        public GaleriaController(IFilesService filesService, IMapper mapper, IGaleriaService galeriaService, ILogger<GaleriaController> logger)
        {
            this.filesService = filesService;
            this.mapper = mapper;
            this.galeriaService = galeriaService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaGaleriaDTO>>> Get([FromQuery]PaginacionDTO paginacionDTO)
        {
            try
            {
                var list = await galeriaService.GetFotos(paginacionDTO);
                var lectura = mapper.Map<List<LecturaGaleriaDTO>>(list);
                return Ok(lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }
        [HttpGet("ronda/{ronda:int}", Name = "RondaFotosPorRonda")]
        public async Task<ActionResult<LecturaGaleriaDTO>> GetPorRonda(int ronda)
        {
            try
            {
                var rondaFotos = await galeriaService.GetFotosPorRonda(ronda);
                if (rondaFotos == null) return NotFound("No hay fotos en esta ronda del campeonato No Encontrada");
                return Ok(mapper.Map<LecturaGaleriaDTO>(rondaFotos));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }
        [HttpGet("{id:int}", Name = "RondaFotosPorId")]
        public async Task<ActionResult<LecturaGaleriaDTO>> GetPorId(int id)
        {
            try
            {
                var rondaFotos = await galeriaService.GetFotosPorId(id);
                if (rondaFotos == null) return NotFound($"No hay fotos relacionadas al id {id}");
                return Ok(mapper.Map<LecturaGaleriaDTO>(rondaFotos));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaGaleriaDTO>> Post([FromForm] CrearGaleriaDTO galeriaDTO)
        {
            try
            {
                if (galeriaDTO.FotoUno == null || galeriaDTO.FotoDos == null || galeriaDTO.FotoTres == null) BadRequest("Imagen no cargada");

                var galeria = mapper.Map<Galeria>(galeriaDTO);
                galeria.FotoUno = await filesService.GuardarImagen(contenedor, galeriaDTO.FotoUno!);
                galeria.FotoDos = await filesService.GuardarImagen(contenedor, galeriaDTO.FotoDos!);
                galeria.FotoTres = await filesService.GuardarImagen(contenedor, galeriaDTO.FotoTres!);

                await galeriaService.AgregarGaleria(galeria);
                var lectura = mapper.Map<LecturaGaleriaDTO>(galeria);
                return CreatedAtRoute("GaleriaPorId", new { id = galeria.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearGaleriaDTO galeriaDTO, int id)
        {
            try
            {
                if (!await galeriaService.Existe(id)) return BadRequest("No existe la galeria que desea modificar");

                var galeriaBD = await galeriaService.GetFotosPorId(id);
                galeriaBD = mapper.Map<Galeria>(galeriaDTO);
                if (galeriaDTO.FotoUno is not null) galeriaBD.FotoUno = await filesService.Editar(galeriaBD!.FotoUno, contenedor, galeriaDTO.FotoUno!);
                if (galeriaDTO.FotoDos is not null) galeriaBD.FotoDos = await filesService.Editar(galeriaBD!.FotoDos, contenedor, galeriaDTO.FotoDos!);
                if (galeriaDTO.FotoTres is not null) galeriaBD.FotoTres = await filesService.Editar(galeriaBD!.FotoTres, contenedor, galeriaDTO.FotoTres!);

                await galeriaService.ModificarGaleria(galeriaBD);
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
                if (!await galeriaService.Existe(id)) return BadRequest("La galeria a borrar no existe");
                var ruta = await galeriaService.Eliminar(id);
                await filesService.Borrar(ruta.Item1, contenedor);
                await filesService.Borrar(ruta.Item2, contenedor);
                await filesService.Borrar(ruta.Item3, contenedor);
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
