using AutoMapper;
using Backend.DTO;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrangController : Controller
{
    private readonly IOrangRepos _repos;
    private readonly IMapper _mapper;

    public OrangController(IOrangRepos orangRepos, IMapper mapper)
    {
        _repos = orangRepos;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrangDTO>))]
    public async Task<ActionResult<ICollection<Orang>>> GetOrangs()
    {
        var orangs = await _repos.GetOrangs();
        var result = _mapper.Map<List<OrangDTO>>(orangs);
        return Ok(result);
    }

    [HttpGet("{nik}")]
    [ProducesResponseType(200, Type = typeof(OrangDTO))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Orang>> GetOrang(string nik)
    {
        var orang = await _repos.GetOrang(nik);
        if (orang == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrangDTO>(orang));
    }

    [HttpGet("umur/{umur}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrangDTO>))]
    public async Task<ActionResult<ICollection<Orang>>> GetOrangDiatasUmur(int umur)
    {
        var list = await _repos.GetOrangsDiatasUmur(umur);
        return Ok(_mapper.Map<List<OrangDTO>>(list));
    }

    [HttpGet("search/{search}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrangDTO>))]
    public async Task<ActionResult<ICollection<Orang>>> GetOrangsWithName(string search)
    {
        var orang = await _repos.GetOrangs(search);

        return Ok(_mapper.Map<OrangDTO>(orang));
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateOrang([FromBody] OrangDTO orangCreate)
    {
        if (CreateOrang == null)
        {
            return BadRequest(ModelState);
        }

        var orangMap = _mapper.Map<Orang>(orangCreate);
        var createResult = await _repos.CreateOrang(orangMap);

        if (!createResult)
        {
            ModelState.AddModelError("", "Internal Error While Saving");
            return StatusCode(500, ModelState);
        }
        return Ok("Success Create Orang");
    }

    [HttpPost("auto")]
    [ProducesResponseType(200, Type = typeof(OrangDTO))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<OrangDTO>> CreateOrangGenerated()
    {
        if (_repos == null)
        {
            Console.WriteLine("Repository is null!");
            return StatusCode(500, "Repository not initialized.");
        }

        var res = new DataGenerator().CreateOrangRandom();

        var createResult = await _repos.CreateOrang(res);
        if (!createResult)
        {
            ModelState.AddModelError("", "Internal Error While Saving");
            return StatusCode(500, ModelState);
        }
        return Ok(_mapper.Map<OrangDTO>(res));
    }

    [HttpGet("tanpaAkta")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrangDTO>))]
    [ProducesResponseType(500)]
    public async Task<ActionResult<OrangDTO>> CreateOrangPercobaan()
    {
        var res = await _repos.GetOrangTanpaAkta();

        return Ok(_mapper.Map<List<OrangDTO>>(res));
    }

    [HttpGet("tanpaKtp")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<OrangDTO>))]
    public async Task<ActionResult<OrangDTO>> GetOrangsTanpaKtp()
    {
        var list = await _repos.GetOrangTanpaKtp();
        var res = _mapper.Map<OrangDTO>(list);
        return Ok(res);
    }
}
