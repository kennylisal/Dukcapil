using System;
using AutoMapper;
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
public class AnggotaKartuKeluargaController(IAnggotaKKServices anggotaKKServices, IMapper mapper)
    : Controller
{
    private readonly IMapper _mapper = mapper;
    private readonly IAnggotaKKServices _services = anggotaKKServices;

    [HttpPost]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<AnggotaKartuKeluarga>))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<AnggotaKartuKeluarga>))]
    public async Task<ActionResult<ControllerResponse<AnggotaKartuKeluarga>>> CreateAnggotaKK(
        [FromBody] SaveAnggotaKKDTO dto
    )
    {
        var anggotaBaru = _mapper.Map<AnggotaKartuKeluarga>(dto);
        var res = await _services.Create(anggotaBaru);
        if (!res.Success)
            return new BadRequestObjectResult(res);
        return new OkObjectResult(res);
    }

    [HttpDelete]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<AnggotaKartuKeluarga>))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<AnggotaKartuKeluarga>))]
    public async Task<ActionResult<ControllerResponse<AnggotaKartuKeluarga>>> DeleteAnggotaKK(
        [FromBody] AnggotaKartuKeluargaDTO dto
    )
    {
        var anggotaTarget = _mapper.Map<AnggotaKartuKeluarga>(dto);
        var res = await _services.Delete(anggotaTarget);
        if (!res.Success)
            return new BadRequestObjectResult(res);

        return new OkObjectResult(res);
    }
}
