using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;

namespace NascarPage.Controllers
{
    [ApiController]
    [Route("api/posiciones")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CarreraController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICarreraService carreraService;
        private readonly ITablaService tablaService;
        private readonly ILogger<CarreraController> logger;

        public CarreraController(IMapper mapper, ICarreraService carreraService, ITablaService tablaService, ILogger<CarreraController> logger)
        {
            this.mapper = mapper;
            this.carreraService = carreraService;
            this.tablaService = tablaService;
            this.logger = logger;
        }

        [HttpGet("{id:int}", Name = "CarreraPorId")]
        public async Task<ActionResult<List<LecturaCarreraDTO>>> GetCarrera(int id)
        {
            List<Carrera> list = await carreraService.GetCarrera(id);
            if (list.Count == 0 || list == null) return NotFound("Carrera no encontrada");
            return Ok(mapper.Map<List<LecturaCarreraDTO>>(list));
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<CrearCarreraDTO> listcrearCarreraDTO)
        {
            var listaCarreraFormateada = mapper.Map<List<Carrera>>(listcrearCarreraDTO);
            await carreraService.AgregarCarrera(listaCarreraFormateada);
            return CreatedAtRoute("CarreraPorId", new { id = listaCarreraFormateada[0].Evento }, listaCarreraFormateada);
        }

        [HttpGet("TablaPosicionesRegular")]
        public async Task<ActionResult<List<LecturaRegularDTO>>> GetCampeonatoRegular()
        {
            var list = mapper.Map<List<LecturaRegularDTO>>(await tablaService.GetTablaRegular());
            return Ok(list);
        }

        [HttpGet("TablaPosicionesPlayoff")]
        public async Task<ActionResult<List<LecturaPlayoffDTO>>> GetCampeonatoPlayoff()
        {
            var list = mapper.Map<List<LecturaPlayoffDTO>>(await tablaService.GetTablaPlayOff());
            return Ok(list);
        }

        [HttpGet("TablaPosicionesPlayoffReducida")]
        public async Task<ActionResult<List<LecturaPlayoffDTO>>> GetCampeonatoPlayoffReducido()
        {
            var list = mapper.Map<List<LecturaPlayoffDTO>>(await tablaService.GetTablaPlayOffReducida());
            return Ok(list);
        }

        [HttpGet("TablaPosicionesManofactura")]
        public async Task<ActionResult<List<LecturaManofacturaDTO>>> GetCampeonatoManofactura()
        {
            var list = mapper.Map<List<LecturaManofacturaDTO>>(await tablaService.GetManofacturas());
            return Ok(list);
        }

        [HttpPost("ReiniciarTemporada")]
        public async Task<ActionResult> ReiniciarTemporada()
        {
            try
            {
                await tablaService.ReiniciarTablasyCarreras();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return BadRequest("Un Error ha ocurrido");
            }
        }
    }
}
