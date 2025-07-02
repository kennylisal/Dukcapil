using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class AktaKelahiran
{
    [Key]
    public int AktaKelahiran_id { get; set; }

    public required string Nik { get; set; }

    public string? NikIbu { get; set; }

    public string? NikAyah { get; set; }

    public required DateOnly Tanggal_lahir { get; set; }

    public required string Tempat_lahir { get; set; }
    public required bool Is_active { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }

    [ForeignKey("NikIbu")]
    public Orang? Ibu { get; set; }
    [ForeignKey("NikAyah")]
    public Orang? Ayah { get; set; }
    [ForeignKey("Nik")]
    public Orang Orang { get; set; } = null!;
}
