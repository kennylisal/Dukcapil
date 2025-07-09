using System;
using System.Diagnostics;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class KartuKeluargaRepos(DataContext context) : BaseRepository(context), IKartuKeluargaRepos
{
    public void Create(KartuKeluarga kk)
    {
        _context.KartuKeluarga.Add(kk);
    }

    public async Task<QueryResults<KartuKeluarga>> GetAll(KartuKeluargaQuery query)
    {
        IQueryable<KartuKeluarga> queryable = _context.KartuKeluarga.AsNoTracking();

        if (query.Kota != null)
        {
            queryable = queryable.Where(kk => kk.Kota == query.Kota);
        }

        if (query.Provinsi != null)
        {
            queryable = queryable.Where(kk => kk.Provinsi == query.Provinsi);
        }
        int totalCount = await queryable.CountAsync();
        List<KartuKeluarga> result = await queryable
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage)
            .ToListAsync();
        return new QueryResults<KartuKeluarga> { Items = result, TotalItems = totalCount };
    }

    public async Task<KartuKeluarga?> GetWithNoKK(string NoKK)
    {
        return await _context
            .KartuKeluarga.AsNoTracking()
            .FirstOrDefaultAsync(k => k.Nomor_KK == NoKK);
    }

    public void Update(KartuKeluarga kk)
    {
        _context.Entry(kk).Property(kk => kk.Kepala_Keluarga).IsModified = false;
        _context.Entry(kk).Property(kk => kk.AnggotaKartuKeluargas).IsModified = false;
        _context.KartuKeluarga.Update(kk);
    }
}
