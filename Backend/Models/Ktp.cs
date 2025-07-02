using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;


public class Ktp
{
    [Key]
    public required int Ktp_id { get; set; }

    public required string Nik { get; set; }

    [ForeignKey("Nik")]
    public Orang Orang { get; set; } = null!;

    public required string Alamat { get; set; }

    public required bool Sudah_Kawin { get; set; }

    public required DateOnly Berlaku_hingga { get; set; }

    public required bool Is_active { get; set; }

    public required string Kota_pembuatan { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }

   
}
