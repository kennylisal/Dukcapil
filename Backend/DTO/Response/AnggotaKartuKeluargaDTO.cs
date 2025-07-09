using System;

namespace Backend.DTO;

public class AnggotaKartuKeluargaDTO
{
    public string KartuKeluargaId { get; set; }

    public required string Nik { get; set; }

    public required string Pendidikan { get; set; }

    public required string Jenis_pekerjaan { get; set; }

    public required bool Masih_anak { get; set; }

    public required bool Is_active { get; set; }

    public required string Peran { get; set; }
}
