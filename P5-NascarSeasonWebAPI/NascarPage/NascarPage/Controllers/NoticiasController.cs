using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/noticias")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiaService noticiaService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<NoticiasController> logger;
        private static readonly string contenedor = "noticias";


        public NoticiasController(INoticiaService noticiaService, IFilesService filesService, IMapper mapper, 
            ILogger<NoticiasController> logger)
        {
            this.noticiaService = noticiaService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaNoticiaDTO>>> Get()
        {
            try
            {
                var list = await noticiaService.GetNoticias();
                return Ok(mapper.Map<List<LecturaNoticiaDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("big")]
        public async Task<ActionResult<List<LecturaNoticiaDTO>>> GetBig()
        {
            try
            {
                var list = await noticiaService.GetNoticiasBig();
                return Ok(mapper.Map<List<LecturaNoticiaDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }

        [HttpGet("half")]
        public async Task<ActionResult<List<LecturaNoticiaDTO>>> GetHalf()
        {
            try
            {
                var list = await noticiaService.GetNoticiasHalf();
                return Ok(mapper.Map<List<LecturaNoticiaDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }



        [HttpGet("{id:int}", Name = "NoticiaPorId")]
        public async Task<ActionResult<LecturaAutoDTO>> GetPorId(int id)
        {
            try
            {
                var noticia = await noticiaService.GetNoticiaId(id);
                if (noticia == null) return NotFound(new { message = "Noticia No Encontrada" });
                return Ok(mapper.Map<LecturaNoticiaDTO>(noticia));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Estamos teniendo inconvenientes tecnicos" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<LecturaNoticiaDTO>> Post([FromForm] CrearNoticiaDTO noticiaDTO)
        {
            try
            {
                if (noticiaDTO.Foto == null) return BadRequest(new { message = "Imagen no cargada" });
                if (string.IsNullOrEmpty(noticiaDTO.Titulo)) return BadRequest(new { message = "Cargue el titulo" });

                var noticia = mapper.Map<Noticia>(noticiaDTO);
                noticia.Foto = await filesService.GuardarImagen(contenedor, noticiaDTO.Foto!);
                await noticiaService.AgregarNoticia(noticia);
                var lectura = mapper.Map<LecturaNoticiaDTO>(noticia);
                return CreatedAtRoute("AutoPorId", new { id = noticia.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest(new { message = "Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar" });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearNoticiaDTO noticiaDTO, int id)
        {
            try
            {
                if (!await noticiaService.Existe(id)) return BadRequest(new { message = "No existe la noticia que desea modificar" });        

                var noticiaBD = await noticiaService.GetNoticiaId(id);
                var respaldoId = noticiaBD!.Id;
                var respaldoFoto = noticiaBD.Foto;
                noticiaBD = mapper.Map(noticiaDTO, noticiaBD);
                if (noticiaDTO.Foto is not null) noticiaBD!.Foto = await filesService.Editar(noticiaBD.Foto, contenedor, noticiaDTO.Foto!);
                else noticiaBD.Foto = respaldoFoto;

                noticiaBD.Id = respaldoId;
                await noticiaService.ModificarNoticia(noticiaBD!);
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
                var existe = await noticiaService.Existe(id);
                if (!existe) return BadRequest(new { message = "Noticia a borrar no existe" });
                var ruta = await noticiaService.EliminarNoticia(id);
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
