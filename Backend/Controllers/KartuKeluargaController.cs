using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class KartuKeluargaController(IKartuKeluargaService service, IMapper mapper) : Controller
{
    private readonly IKartuKeluargaService _service = service;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(QueryResults<KartuKeluargaDTO>))]
    public async Task<ActionResult<QueryResults<KartuKeluargaDTO>>> GetAll(
        [FromQuery] KartuKeluargaQuery query
    )
    {
        var kks = await _service.GetAll(query);
        var res = _mapper.Map<QueryResults<KartuKeluargaDTO>>(kks);
        return Ok(res);
    }

    [HttpGet("{noKK}")]
    [ProducesResponseType(200, Type = typeof(KartuKeluargaDTO))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<KartuKeluargaDTO>> GetKartuWithNoKK(string noKK)
    {
        var kks = await _service.GetWithNoKK(noKK);
        var res = _mapper.Map<KartuKeluargaDTO>(kks);
        return Ok(res);
    }

    [HttpPost]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<KartuKeluargaDTO>))]
    [ProducesResponseType(404, Type = typeof(ControllerResponse<KartuKeluarga>))]
    public async Task<ActionResult> CreateKartuKeluarga(SaveKartuKeluargaDTO dto)
    {
        var kartuKeluarga = _mapper.Map<KartuKeluarga>(dto);
        var action = await _service.Craete(kartuKeluarga);

        if (!action.Success)
            return new BadRequestObjectResult(action);

        var res = _mapper.Map<ControllerResponse<KartuKeluargaDTO>>(action);
        return new OkObjectResult(res);
    }

    [HttpPut]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<KartuKeluargaDTO>))]
    [ProducesResponseType(404, Type = typeof(ControllerResponse<KartuKeluarga>))]
    public async Task<ActionResult> UpdateKartuKeluarga(KartuKeluargaDTO dto)
    {
        var kartuKeluarga = _mapper.Map<KartuKeluarga>(dto);
        var action = await _service.Update(kartuKeluarga);
        if (!action.Success)
            return new BadRequestObjectResult(action);

        var res = _mapper.Map<ControllerResponse<KartuKeluargaDTO>>(action);
        return new OkObjectResult(res);
    }
}
