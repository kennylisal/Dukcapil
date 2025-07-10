using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO;

public class KtpDTO
{
    [Required]
    public required int Ktp_id { get; set; }

    [Required]
    public required string Nik { get; set; }

    [Required]
    public required string Alamat { get; set; }

    [Required]
    public required bool Sudah_Kawin { get; set; }

    [Required]
    public required DateOnly Berlaku_hingga { get; set; }

    [Required]
    public required bool Is_active { get; set; }

    [Required]
    public required string Kota_pembuatan { get; set; }

    [Required]
    public required DateOnly Tanggal_penerbitan { get; set; }

    public OrangDTO? Orang { get; set; }
}
