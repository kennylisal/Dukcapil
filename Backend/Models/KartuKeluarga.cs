using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class KartuKeluarga
{
    [Key]
    public required string Nomor_KK { get; set; }

    public required string Alamat { get; set; }

    public required string Provinsi { get; set; }

    public required string Kota { get; set; }

    public required string Kode_pos { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }

    public required bool Is_active { get; set; }

    public required string Nik_kepala_keluarga { get; set; }

    [ForeignKey("Nik_kepala_keluarga")]
    public required Orang Kepala_Keluarga { get; set; }

    public ICollection<AnggotaKartuKeluarga> AnggotaKartuKeluargas { get; set; }
}
