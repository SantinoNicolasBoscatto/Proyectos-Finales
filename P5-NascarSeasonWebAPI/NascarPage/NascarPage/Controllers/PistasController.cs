using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/pistas")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PistasController : ControllerBase
    {
        private readonly IPistaService pistaService;
        private readonly IFilesService filesService;
        private readonly IMapper mapper;
        private readonly ILogger<PistasController> logger;
        private static readonly string contenedor = "pistas";

        public PistasController(IPistaService pistaService, IFilesService filesService, IMapper mapper, ILogger<PistasController> logger)
        {
            this.pistaService = pistaService;
            this.filesService = filesService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LecturaPistaDTO>>> Get(bool calendario)
        {
            try
            {
                var list = await pistaService.GetPistas(calendario);
                return Ok(mapper.Map<List<LecturaPistaDTO>>(list));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpGet("{id:int}", Name = "PistaPorId")]
        public async Task<ActionResult<LecturaPistaDTO>> GetPorId(int id)
        {
            try
            {
                var pista = await pistaService.GetPistaId(id);
                if (pista == null) return NotFound("Pista No Encontrada");
                return Ok(mapper.Map<LecturaPistaDTO>(pista));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpGet("orden/{Orden:int}", Name = "PistaPorOrden")]
        public async Task<ActionResult<LecturaPistaDTO>> GetPorOrden(int Orden)
        {
            try
            {
                var pista = await pistaService.GetPistaOrden(Orden);
                if (pista == null) return NotFound("Pista No Encontrada");
                return Ok(mapper.Map<LecturaPistaDTO>(pista));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Estamos teniendo inconvenientes tecnicos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LecturaAutoDTO>> Post([FromForm] CrearPistaDTO pistaDTO)
        {
            try
            {
                if (pistaDTO.FotoPrimaria == null || pistaDTO.FotoSecundaria == null || pistaDTO.FotoTerciaria == null) return BadRequest("Imagen no cargada");
                if (await pistaService.ExisteFecha(pistaDTO.Orden)) return BadRequest("Ya existe un circuito con esa fecha asignada");

                var pista = mapper.Map<Pista>(pistaDTO);
                pista.FotoPrimaria = await filesService.GuardarImagen(contenedor, pistaDTO.FotoPrimaria!);
                pista.FotoSecundaria = await filesService.GuardarImagen(contenedor, pistaDTO.FotoSecundaria!);
                pista.FotoTerciaria = await filesService.GuardarImagen(contenedor, pistaDTO.FotoTerciaria!);
                await pistaService.AgregarPista(pista);
                var lectura = mapper.Map<LecturaPistaDTO>(pista);
                return CreatedAtRoute("PistaPorId", new { id = pista.Id }, lectura);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromForm] CrearPistaDTO pistaDTO, int id)
        {
            try
            {
                if (!await pistaService.Existe(id)) return BadRequest("No existe la Pista que desea modificar");

                var pistaBD = await pistaService.GetPistaId(id);
                pistaBD = mapper.Map<Pista>(pistaDTO);
                if (pistaDTO.FotoPrimaria is not null) pistaBD.FotoPrimaria = await filesService.Editar(pistaBD!.FotoPrimaria, contenedor, pistaDTO.FotoPrimaria);
                if (pistaDTO.FotoSecundaria is not null) pistaBD.FotoSecundaria = await filesService.Editar(pistaBD!.FotoSecundaria, contenedor, pistaDTO.FotoSecundaria);
                if (pistaDTO.FotoTerciaria is not null) pistaBD.FotoTerciaria = await filesService.Editar(pistaBD!.FotoTerciaria, contenedor, pistaDTO.FotoTerciaria);

                await pistaService.ModificarPista(pistaBD);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("{id:int}/intercambio/{idIntercambio:int}")]
        public async Task<ActionResult> PutOrden(int id, int idIntercambio)
        {
            try
            {
                if (!await pistaService.ExisteEnCalendario(id) || !await pistaService.ExisteEnCalendario(idIntercambio)) 
                    return NotFound("Alguna de las pistas enviadas no existe");

                await pistaService.ModificarOrdenPistas(id, idIntercambio);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPut("entra/{idEntra:int}/sale/{idSale:int}")]
        public async Task<ActionResult> ModficarCalendario(int idEntra, int idSale)
        {
            try
            {
                if (!await pistaService.ExisteEnCalendario(idSale)) return NotFound("La pista enviada no existe o no esta en el calendario");
                if (!await pistaService.ExisteFueraEnCalendario(idEntra)) return NotFound("La pista enviada no existe o  esta en el calendario");

                await pistaService.AgregarySacarPistaCalendario(idEntra, idSale);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Ha ocurrido un error en la peticion, porfavor revise los datos y vuelva a intentar");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(JsonPatchDocument<PatchPistaDTO> patchDocument, int id)
        {
            try
            {
                if (patchDocument is null) return BadRequest("Error en el documento Patch");

                var pistaBD = await pistaService.GetPistaId(id);
                if (pistaBD is null) return NotFound();

                var pistaDTO = mapper.Map<PatchPistaDTO>(pistaBD);
                patchDocument.ApplyTo(pistaDTO, ModelState);

                var esValido = TryValidateModel(pistaDTO);
                if (!esValido) return BadRequest("Ingreso Datos erroneos a la pista");

                var pista = mapper.Map(pistaDTO, pistaBD);
                await pistaService.ModificarPista(pista);
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
                var existe = await pistaService.Existe(id);
                if (!existe) return BadRequest("La pista a borrar no existe");
                var ruta = await pistaService.EliminarPista(id);
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
