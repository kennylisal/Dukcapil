using AutoMapper;
using Backend.DTO;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KtpControlller : Controller
{
    private readonly IKtpRepos _repos;
    private readonly IMapper _mapper;

    private readonly IOrangRepos _orangRepos;

    public KtpControlller(IKtpRepos repos, IMapper mapper, IOrangRepos orangRepos)
    {
        _repos = repos;
        _mapper = mapper;
        _orangRepos = orangRepos;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<KtpDTO>))]
    public async Task<ActionResult<ICollection<KtpDTO>>> getKtps()
    {
        var ktps = await _repos.GetKtps();
        var result = _mapper.Map<List<KtpDTO>>(ktps);
        return Ok(result);
    }

    [HttpGet("{nik}")]
    [ProducesResponseType(200, Type = typeof(KtpDTO))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<KtpDTO>> getKtp(string nik)
    {
        var ktps = await _repos.getKtpByNik(nik);
        if (ktps == null)
        {
            return NotFound();
        }
        var result = _mapper.Map<KtpDTO>(ktps);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> CreateKTP([FromBody] KtpDTO ktp, [FromBody] string nik)
    {
        var data = await _repos.CreateKtp(_mapper.Map<Ktp>(ktp), nik);
        if (!data)
        {
            return StatusCode(500);
        }
        return Ok();
    }

    [HttpPost("auto")]
    [ProducesResponseType(200)]
    [ProducesResponseType(200, Type = typeof(KtpDTO))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<KtpDTO>> CreateKtp()
    {
        var listOrang = await _orangRepos.GetOrangTanpaKtp();
        if (listOrang.Count == 0)
        {
            return Ok("No Data Available");
        }
        var orangPilihan = new Faker().PickRandom(listOrang);

        var ktp = DataGenerator.CreateKtpBasic(orangPilihan);
        var createStatus = await _repos.CreateKtp(ktp, orangPilihan.Nik);
        if (createStatus)
        {
            return Ok(_mapper.Map<KtpDTO>(ktp));
        }
        else
        {
            return StatusCode(500);
        }
    }
}
