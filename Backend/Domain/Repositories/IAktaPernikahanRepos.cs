using System;
using Backend.Domain.Models.Queries;
using Backend.DTO;
using Backend.Models;

namespace Backend.Interfaces;

public interface IAktaPernikahanRepos
{
    Task<QueryResults<AktaPernikahan>> GetAll(RequestQuery query);
    Task<AktaPernikahan?> GetAktaWithOneOfNik(string nik);

    void Create(AktaPernikahan akta);

    void Update(AktaPernikahan akta);
}
