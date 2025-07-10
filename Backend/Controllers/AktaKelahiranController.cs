using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services;
using Backend.DTO;
using Backend.DTO.Request;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class AktaKelahiranController(IAktaKelahiranServices services, IMapper mapper) : Controller
{
    private readonly IAktaKelahiranServices _service = services;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(QueryResults<AktaKelahiranDTO>))]
    public async Task<ActionResult<QueryResults<OrangDTO>>> GetOrangs(
        [FromQuery] RequestQuery query
    )
    {
        var aktas = await _service.GetAll(query);
        var res = _mapper.Map<QueryResults<AktaKelahiranDTO>>(aktas);
        return Ok(res);
    }

    [HttpGet("{nik}")]
    [ProducesResponseType(200, Type = typeof(QueryResults<AktaKelahiranDTO>))]
    public async Task<ActionResult<OrangDTO>> GetOrangWithNik(string nik)
    {
        var akta = await _service.GetWithNik(nik);
        if (akta == null)
            return BadRequest("Nik tidak valid / tidak ditemukan");

        var result = _mapper.Map<AktaKelahiranDTO>(akta);
        return new OkObjectResult(result);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateAktaKelahiran([FromBody] SaveAktaKelahiranDTO dto)
    {
        var dataBaru = _mapper.Map<AktaKelahiran>(dto);
        var res = await _service.Create(dataBaru);
        if (!res.Success)
        {
            return new BadRequestObjectResult(res);
        }
        return new OkObjectResult(res);
    }

    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateAktaKelahiran([FromBody] AktaKelahiranDTO dto)
    {
        var dataTarget = _mapper.Map<AktaKelahiran>(dto);
        var res = await _service.Update(dataTarget);
        if (!res.Success)
            return new BadRequestObjectResult(res);
        return new OkObjectResult(res);
    }
}
