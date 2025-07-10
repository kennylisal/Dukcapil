using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services;
using Backend.Domain.Services.Communication;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.DTO.Response;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class OrangController : Controller
{
    private readonly IOrangServices _services;
    private readonly IMapper _mapper;

    public OrangController(IOrangServices services, IMapper mapper)
    {
        _services = services;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(QueryResults<OrangDTO>))]
    public async Task<ActionResult<QueryResults<OrangDTO>>> GetOrangs([FromQuery] OrangQuery query)
    {
        var orangs = await _services.GetAll(query);
        var result = _mapper.Map<QueryResults<OrangDTO>>(orangs);
        return Ok(result);
    }

    [HttpGet("{nik}")]
    [ProducesResponseType(200, Type = typeof(OrangDTO))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<Orang>))]
    public async Task<ActionResult<Orang>> GetOrang(string nik)
    {
        var orang = await _services.GetOrang(nik);
        if (orang == null)
        {
            return BadRequest(new ControllerResponse<Orang>("Nik tidak ditemukan"));
        }

        var res = _mapper.Map<OrangDTO>(orang);
        return Ok(res);
    }

    [HttpPost]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<Orang>))]
    // [ProducesResponseType(400, Type = typeof(ControllerResponse<Orang>))]
    public async Task<ActionResult> CreateOrang([FromBody] SaveOrangDTO orangCreate)
    {
        var OrangBaru = _mapper.Map<Orang>(orangCreate);
        var response = await _services.Create(OrangBaru);

        return Ok(_mapper.Map<ControllerResponse<OrangDTO>>(response));
    }

    [HttpPut("{nik}")]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<OrangDTO>))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<OrangDTO>))]
    public async Task<ActionResult> UpdateOrang(string nik, [FromBody] SaveOrangDTO orangCreate)
    {
        var OrangTarget = _mapper.Map<Orang>(orangCreate);
        var response = await _services.Update(nik, OrangTarget);

        if (!response.Success)
        {
            return new BadRequestObjectResult(response);
        }

        var result = _mapper.Map<ControllerResponse<OrangDTO>>(response);
        return Ok(result);
    }
}
