using System;

namespace Backend.DTO;

public class KtpDTO
{
    public required int Ktp_id { get; set; }

    public required string Nik { get; set; }

    public required string Alamat { get; set; }

    public required bool Sudah_Kawin { get; set; }

    public required DateOnly Berlaku_hingga { get; set; }

    public required bool Is_active { get; set; }

    public required string Kota_pembuatan { get; set; }

    public required DateOnly Tanggal_penerbitan { get; set; }
}
