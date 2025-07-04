using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class AktaPernikahan
{
    public required int Id_akta_pernikahan { get; set; }

    public required string Nik_suami { get; set; }

    public required string Nik_istri { get; set; }

    public required DateOnly Tanggal_pernikahan { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }

    public required string Agama_pernikahan { get; set; }

    public required bool Is_active { get; set; }

    public required string Lokasi_penerbitan { get; set; }

    [ForeignKey("Nik_suami")]
    public required Orang Suami { get; set; }

    [ForeignKey("Nik_istri")]
    public required Orang Istri { get; set; }
}
