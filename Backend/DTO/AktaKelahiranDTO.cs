using System;

namespace Backend.DTO;

public class AktaKelahiranDTO
{
    public int AktaKelahiran_id { get; set; }

    public required string Nik { get; set; }

    public string? NikIbu { get; set; }

    public string? NikAyah { get; set; }

    public required bool Is_active { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }
}
