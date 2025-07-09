using System;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AktaPernikahanRepos(DataContext context)
    : BaseRepository(context),
        IAktaPernikahanRepos
{
    public void Create(AktaPernikahan akta)
    {
        _context.AktaPernikahans.Add(akta);
    }

    public async Task<AktaPernikahan?> GetAktaWithOneOfNik(string nik)
    {
        return await _context.AktaPernikahans.FirstOrDefaultAsync(ak =>
            ak.Nik_istri == nik || ak.Nik_suami == nik
        );
    }

    public async Task<QueryResults<AktaPernikahan>> GetAll(RequestQuery query)
    {
        IQueryable<AktaPernikahan> queryable = _context.AktaPernikahans.AsNoTracking();
        int itemCount = await queryable.CountAsync();

        List<AktaPernikahan> result = await queryable
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage)
            .ToListAsync();
        return new QueryResults<AktaPernikahan> { Items = result, TotalItems = itemCount };
    }

    public void Update(AktaPernikahan akta)
    {
        _context.AktaPernikahans.Update(akta);
    }
}
