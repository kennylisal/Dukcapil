using System;

namespace Backend.Domain.Models.Queries;

public class KartuKeluargaQuery : RequestQuery
{
    public string? Provinsi { get; set; }
    public string? Kota { get; set; }

    public KartuKeluargaQuery(
        string? provinsi,
        string? kota,
        string? nik_kepala,
        int page,
        int itemPerPage
    )
        : base(page, itemPerPage)
    {
        Provinsi = provinsi;
        Kota = kota;
    }
}
