using System;

namespace Backend.Domain.Models.Queries;

public class KtpQuery : RequestQuery
{
    public string? Kota { get; set; }

    public bool? SudahKawin { get; set; }

    public KtpQuery(string? provinsi, bool? sudahKawin, int page, int itemPerPage)
        : base(page, itemPerPage)
    {
        Kota = provinsi;
        SudahKawin = sudahKawin;
    }
}
