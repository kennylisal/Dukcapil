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
public class KtpControlller : Controller
{
    private readonly IKtpServices _service;
    private readonly IMapper _mapper;

    //     private readonly IOrangRepos _orangRepos;

    public KtpControlller(IKtpServices services, IMapper mapper)
    {
        _service = services;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(QueryResults<KtpDTO>))]
    public async Task<ActionResult<QueryResults<KtpDTO>>> GetAll([FromQuery] KtpQuery query)
    {
        var ktps = await _service.GetAll(query);
        var result = _mapper.Map<QueryResults<KtpDTO>>(ktps);
        return Ok(result);
    }

    [HttpGet("nik/{nik}")]
    [ProducesResponseType(200, Type = typeof(KtpDTO))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<KtpDTO>> GetKtpWithNik(string nik)
    {
        var ktp = await _service.GetKtpWithNik(nik);
        if (ktp == null)
        {
            return BadRequest("Nik tidak valid / tidak Ditemukan");
        }
        return new OkObjectResult(_mapper.Map<KtpDTO>(ktp));
    }

    [HttpPost]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<KtpDTO>))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<Ktp>))]
    public async Task<IActionResult> CreateKtp([FromBody] SaveKtpDTO dto)
    {
        var ktp = _mapper.Map<Ktp>(dto);
        var response = await _service.Create(ktp, ktp.Nik);
        if (!response.Success)
            return new BadRequestObjectResult(response);

        return new OkObjectResult(_mapper.Map<ControllerResponse<KtpDTO>>(response));
    }

    [HttpPut]
    [ProducesResponseType(204, Type = typeof(ControllerResponse<KtpDTO>))]
    [ProducesResponseType(400, Type = typeof(ControllerResponse<Ktp>))]
    public async Task<ActionResult> UpdateKtp([FromBody] KtpDTO dto)
    {
        var ktp = _mapper.Map<Ktp>(dto);
        var response = await _service.Update(ktp);
        if (!response.Success)
        {
            return new BadRequestObjectResult(response);
        }
        return new OkObjectResult(_mapper.Map<ControllerResponse<KtpDTO>>(response));
    }
}
