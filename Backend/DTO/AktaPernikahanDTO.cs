using System;

namespace Backend.DTO;

public class AktaPernikahanDTO
{
    public required int Id_akta_pernikahan { get; set; }

    public required string Nik_suami { get; set; }

    public required string Nik_istri { get; set; }

    public required DateOnly Tanggal_pernikahan { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }

    public required string Agama_pernikahan { get; set; }

    public required bool Is_active { get; set; }
}
