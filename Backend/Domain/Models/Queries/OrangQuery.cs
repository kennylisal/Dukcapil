using System;

namespace Backend.Domain.Models.Queries;

public class OrangQuery : RequestQuery
{
    public string? Name { get; set; }
    public int? Umur { get; set; }

    public bool? CariUmurDiatas { get; set; }

    public bool? PunyaKeluarga { get; set; }

    public char? Kelamin { get; set; }

    public OrangQuery(
        string? name,
        int? umur,
        bool? cariUmurDiatas,
        bool? punyaKeluarga,
        char? kelamin,
        int page,
        int itemPerPage
    )
        : base(page, itemPerPage)
    {
        Name = name;
        Umur = umur;
        CariUmurDiatas = cariUmurDiatas;
        PunyaKeluarga = punyaKeluarga;
        Kelamin = kelamin;
    }
}
