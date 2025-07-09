using System.Threading.Tasks;
using Backend.Data;
using Backend.Domain.Models.Queries;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Models;
using Backend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class OrangRepos(DataContext context) : BaseRepository(context), IOrangRepos
{
    public void Create(Orang orang)
    {
        _context.Orang.Add(orang);
    }

    public async Task<QueryResults<Orang>> GetAll(OrangQuery query)
    {
        IQueryable<Orang> queryable = _context
            .Orang.Include(o => o.AnggotaKartuKeluarga)
            .AsNoTracking();

        if (query.Name != null)
        {
            queryable = queryable.Where(q => q.Nama.Contains(query.Name));
        }
        if (query.Umur.HasValue)
        {
            if (query.CariUmurDiatas.HasValue)
            {
                queryable = queryable.Where(o =>
                    DateTime.Now.Year - o.Tanggal_lahir.Year < query.Umur
                );
            }
            else
            {
                queryable = queryable.Where(o =>
                    DateTime.Now.Year - o.Tanggal_lahir.Year > query.Umur
                );
            }
        }
        if (query.PunyaKeluarga.HasValue)
        {
            queryable = queryable.Where(o => o.AnggotaKartuKeluarga != null == query.PunyaKeluarga);
        }
        if (query.Kelamin != null)
        {
            queryable = queryable.Where(o => o.Kelamin == query.Kelamin);
        }

        int totalItems = await queryable.CountAsync();

        List<Orang> results = await queryable
            .Skip((query.Page - 1) * query.ItemPerPage)
            .Take(query.ItemPerPage)
            .ToListAsync();
        return new QueryResults<Orang> { Items = results, TotalItems = totalItems };
    }

    public async Task<Orang?> GetWithNik(string Nik)
    {
        return await _context.Orang.FirstOrDefaultAsync(o => o.Nik == Nik);
    }

    public void Update(Orang orang)
    {
        _context.Orang.Update(orang);
    }
}
