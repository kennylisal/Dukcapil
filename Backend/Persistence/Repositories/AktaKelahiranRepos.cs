using System;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Interfaces;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AktaKelahiranRepos(DataContext context) : BaseRepository(context), IAktaKelahiranRepos
{
    public void Create(AktaKelahiran aktaKelahiran)
    {
        _context.AktaKelahiran.Add(aktaKelahiran);
    }

    public async Task<AktaKelahiran?> GetAktaByNik(string Nik)
    {
        return await _context.AktaKelahiran.AsNoTracking().FirstOrDefaultAsync(ak => ak.Nik == Nik);
    }

    public async Task<QueryResults<AktaKelahiran>> GetAll(RequestQuery query)
    {
        IQueryable<AktaKelahiran> queryable = _context.AktaKelahiran.AsNoTracking();

        int totalCount = await queryable.CountAsync();

        List<AktaKelahiran> result = await queryable
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage)
            .ToListAsync();

        return new QueryResults<AktaKelahiran> { Items = result, TotalItems = totalCount };
    }

    public void Update(AktaKelahiran akta)
    {
        _context.AktaKelahiran.Update(akta);
    }
}
