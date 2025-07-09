using System;
using AutoMapper;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KartuKeluargaController(IKartuKeluargaRepos kartuKeluargaRepos, IMapper mapper)
    : Controller
{
    private readonly IKartuKeluargaRepos _repos = kartuKeluargaRepos;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<KartuKeluargaDTO>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<KartuKeluargaDTO>>> GetAllKartuKeluarga()
    {
        var res = await _repos.GetAll();

        return Ok(_mapper.Map<IEnumerable<KartuKeluargaDTO>>(res));
    }

    [HttpGet("/id/{nokk}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<KartuKeluargaDTO>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<KartuKeluargaDTO>>> GetKartuKeluargaByid(string nokk)
    {
        var res = await _repos.GetWithNoKK(nokk);

        return Ok(_mapper.Map<IEnumerable<KartuKeluargaDTO>>(res));
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> CreateKartuKeluarga(
        [FromBody] KartuKeluargaDTO kartuKeluargaDTO,
        string Nik_kepala_keluarga
    )
    {
        try
        {
            var KartuKeluarga = _mapper.Map<KartuKeluarga>(kartuKeluargaDTO);
            await _repos.Create(KartuKeluarga, Nik_kepala_keluarga);
            return Ok();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("auto")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<KartuKeluargaDTO>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<KartuKeluargaDTO>>> CreateKKAuto()
    {
        var res = await _repos.CreateKartuKeluargaAutoBasic(20);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<IEnumerable<KartuKeluargaDTO>>(res));
    }
}
