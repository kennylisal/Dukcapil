using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class AnggotaKartuKeluarga
{
    [ForeignKey("Kartu_keluarga_id")]
    public KartuKeluarga KartuKeluarga { get; set; } = null!;

    [ForeignKey("Nik")]
    public Orang Orang { get; set; } = null!;

    public string KartuKeluargaId { get; set; }

    public required string Nik { get; set; }

    public required string Pendidikan { get; set; }

    public required string Jenis_pekerjaan { get; set; }

    public required bool Masih_anak { get; set; }

    public required bool Is_active { get; set; }

    public required string Peran { get; set; }
}
