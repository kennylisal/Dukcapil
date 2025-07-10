using System;
using AutoMapper;
using Backend.Domain.Models.Queries;
using Backend.Domain.Services;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[Produces("application/json")]
[ApiController]
public class AktaPernikahanController(IAktaPernikahanServices services, IMapper mapper) : Controller
{
    private readonly IAktaPernikahanServices _services = services;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(QueryResults<AktaPernikahanDTO>))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<QueryResults<AktaPernikahanDTO>>> GetAllAkta(
        [FromQuery] RequestQuery query
    )
    {
        var res = await _services.GetAll(query);
        return Ok(res);
    }

    [HttpGet("{nikAnggota}")]
    [ProducesResponseType(200, Type = typeof(QueryResults<AktaPernikahanDTO>))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AktaPernikahanDTO>> GetAktaWithOneNIk(string nikAnggota)
    {
        var res = await _services.GetWithNik(nikAnggota);
        if (res == null)
            return new BadRequestObjectResult(res);

        return Ok(res);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateAktaPernikahan([FromBody] SaveAktaPernikahanDTO dto)
    {
        var akta = _mapper.Map<AktaPernikahan>(dto);
        var res = await _services.Create(akta);
        if (!res.Success)
            return new BadRequestObjectResult(res);
        return Ok(res);
    }

    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateAktaPernikahan([FromBody] AktaPernikahanDTO dto)
    {
        var akta = _mapper.Map<AktaPernikahan>(dto);
        var res = await _services.Update(akta);
        if (!res.Success)
            return new BadRequestObjectResult(res);

        return Ok(res);
    }
}
