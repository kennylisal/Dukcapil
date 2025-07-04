using System;
using AutoMapper;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AktaPernikahanController(
    IAktaPernikahanRepos aktaPernikahanRepos,
    IMapper mapper,
    IOrangRepos orangRepos
) : Controller
{
    private readonly IAktaPernikahanRepos _repos = aktaPernikahanRepos;
    private readonly IMapper _mapper = mapper;

    private readonly IOrangRepos _orangRepos = orangRepos;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AktaPernikahanDTO>))]
    public async Task<ActionResult<IEnumerable<AktaPernikahanDTO>>> GetAllAktaPernikahan()
    {
        var res = await _repos.getAllAktaPernikahan();
        return Ok(_mapper.Map<AktaPernikahanDTO>(res));
    }

    [HttpGet("{Nik}")]
    [ProducesResponseType(200, Type = typeof(AktaPernikahanDTO))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AktaPernikahanDTO>> GetAktaPernikahanWithNik(string Nik)
    {
        var res = await _repos.GetAktaWithOneOfNik(Nik);
        if (res != null)
            return Ok(_mapper.Map<AktaPernikahanDTO>(res));
        else
            return NotFound();
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType(200, Type = typeof(AktaPernikahanDTO))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AktaPernikahanDTO>> GetAktaPernikahanWithId(int id)
    {
        var res = await _repos.GetAktaWithId(id);
        if (res == null)
        {
            return NotFound();
        }
        else
            return Ok(_mapper.Map<AktaPernikahanDTO>(res));
    }

    // [HttpPost("auto")]
    // [ProducesResponseType(204, Type = typeof(AktaPernikahanDTO))]
    // [ProducesResponseType(500)]
    // public async Task<ActionResult<AktaPernikahanDTO> CreateAktaPernikahanAuto() {
    //     var listCowok = await _orangRepos.GetOrangsWithSpesificGender('L');
    //     var listCewek = await _orangRepos.GetOrangsWithSpesificGender('P');

    //     var seed = new Faker<AktaPernikahan>("id_ID").RuleFor(o => tanggla)
    // }
}
