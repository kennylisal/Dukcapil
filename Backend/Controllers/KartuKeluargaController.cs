using System;
using AutoMapper;
using Backend.DTO;
using Backend.Interfaces;
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

    [HttpPost("auto")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<KartuKeluargaDTO>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<KartuKeluargaDTO>>> CreateKKAuto()
    {
        var res = _repos.CreateKartuKeluargaAutoBasic(20);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ICollection<KartuKeluargaDTO>>(res));
    }
}
