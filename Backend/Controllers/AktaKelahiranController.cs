// using System;
// using AutoMapper;
// using Backend.DTO;
// using Backend.Helper;
// using Backend.Interfaces;
// using Backend.Models;
// using Bogus;
// using Microsoft.AspNetCore.Mvc;

// namespace Backend.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class AktaKelahiranController(
//     IAktaKelahiranRepos repos,
//     IOrangRepos orangRepos,
//     IMapper mapper
// ) : Controller
// {
//     private readonly IAktaKelahiranRepos _repos = repos;
//     private readonly IMapper _mapper = mapper;

//     private readonly IOrangRepos _orangRepos = orangRepos;

//     [HttpGet]
//     [ProducesResponseType(200, Type = typeof(IEnumerable<AktaKelahiranDTO>))]
//     public async Task<ActionResult<ICollection<OrangDTO>>> GetOrangs()
//     {
//         var aktas = await _repos.GetAll();
//         var res = _mapper.Map<List<AktaKelahiranDTO>>(aktas);
//         return Ok(res);
//     }

//     [HttpGet]
//     [ProducesResponseType(200, Type = typeof(AktaKelahiranDTO))]
//     [ProducesResponseType(500)]
//     public async Task<ActionResult> GetAktaKelahiran([FromBody] string Nik)
//     {
//         var res = _repos.GetAktaByNik(Nik);
//         if (res == null)
//         {
//             return StatusCode(500);
//         }
//         return Ok();
//     }

//     [HttpPost]
//     [ProducesResponseType(200)]
//     [ProducesResponseType(500)]
//     public async Task<ActionResult> CreateAktaKelahiran(
//         [FromBody] AktaKelahiranDTO dTO,
//         [FromBody] string? nikIbu,
//         [FromBody] string? nikAyah
//     )
//     {
//         var akta_kelahiran = _mapper.Map<AktaKelahiran>(dTO);
//         var res = await _repos.CreateAkta(akta_kelahiran, nikIbu, nikAyah);
//         if (!res)
//         {
//             return StatusCode(500);
//         }
//         return Ok();
//     }

//     [HttpPost("auto")]
//     [ProducesResponseType(200, Type = typeof(AktaKelahiran))]
//     [ProducesResponseType(500)]
//     public async Task<ActionResult<AktaKelahiran>> CreateOrangGenerated()
//     {
//         var listOrang = await _orangRepos.GetTanpaAkta();

//         if (listOrang.Count == 0)
//         {
//             return StatusCode(500);
//         }

//         var orangPilihan = new Faker().PickRandom(listOrang);

//         var res = DataGenerator.CreateAktaKelahiranBasic(orangPilihan);

//         var createResult = await _repos.CreateAkta(res, null, null);
//         if (!createResult)
//         {
//             return StatusCode(500);
//         }

//         return Ok(_mapper.Map<AktaKelahiranDTO>(res));
//     }
// }
