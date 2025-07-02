using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orang",
                columns: table => new
                {
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal_lahir = table.Column<DateOnly>(type: "date", nullable: false),
                    Tempat_lahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kelamin = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Kewarganegaraan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orang", x => x.Nik);
                }
            );

            migrationBuilder.CreateTable(
                name: "AktaKelahiran",
                columns: table => new
                {
                    AktaKelahiran_id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NikIbu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NikAyah = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tanggal_lahir = table.Column<DateOnly>(type: "date", nullable: false),
                    Tempat_lahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false),
                    Tanggal_penerbitan = table.Column<DateOnly>(type: "date", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktaKelahiran", x => x.AktaKelahiran_id);
                    table.ForeignKey(
                        name: "FK_AktaKelahiran_Orang_Nik",
                        column: x => x.Nik,
                        principalTable: "Orang",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AktaKelahiran_Orang_NikAyah",
                        column: x => x.NikAyah,
                        principalTable: "Orang",
                        principalColumn: "Nik"
                    );
                    table.ForeignKey(
                        name: "FK_AktaKelahiran_Orang_NikIbu",
                        column: x => x.NikIbu,
                        principalTable: "Orang",
                        principalColumn: "Nik"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "KartuKeluarga",
                columns: table => new
                {
                    Nomor_KK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode_pos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal_penerbitan = table.Column<DateOnly>(type: "date", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false),
                    Nik_kepala_keluarga = table.Column<string>(
                        type: "nvarchar(450)",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartuKeluarga", x => x.Nomor_KK);
                    table.ForeignKey(
                        name: "FK_KartuKeluarga_Orang_Nik_kepala_keluarga",
                        column: x => x.Nik_kepala_keluarga,
                        principalTable: "Orang",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Ktp",
                columns: table => new
                {
                    Ktp_id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sudah_Kawin = table.Column<bool>(type: "bit", nullable: false),
                    Berlaku_hingga = table.Column<DateOnly>(type: "date", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false),
                    Kota_pembuatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanggal_penerbitan = table.Column<DateOnly>(type: "date", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ktp", x => x.Ktp_id);
                    table.ForeignKey(
                        name: "FK_Ktp_Orang_Nik",
                        column: x => x.Nik,
                        principalTable: "Orang",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AnggotaKartuKeluarga",
                columns: table => new
                {
                    KartuKeluargaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pendidikan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jenis_pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masih_anak = table.Column<bool>(type: "bit", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false),
                    Peran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kartu_keluarga_id = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AnggotaKartuKeluarga",
                        x => new { x.KartuKeluargaId, x.Nik }
                    );
                    table.ForeignKey(
                        name: "FK_AnggotaKartuKeluarga_KartuKeluarga_KartuKeluargaId",
                        column: x => x.KartuKeluargaId,
                        principalTable: "KartuKeluarga",
                        principalColumn: "Nomor_KK",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AnggotaKartuKeluarga_Orang_Nik",
                        column: x => x.Nik,
                        principalTable: "Orang",
                        principalColumn: "Nik",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_AktaKelahiran_Nik",
                table: "AktaKelahiran",
                column: "Nik",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_AktaKelahiran_NikAyah",
                table: "AktaKelahiran",
                column: "NikAyah"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AktaKelahiran_NikIbu",
                table: "AktaKelahiran",
                column: "NikIbu"
            );

            migrationBuilder.CreateIndex(
                name: "IX_AnggotaKartuKeluarga_Nik",
                table: "AnggotaKartuKeluarga",
                column: "Nik",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_KartuKeluarga_Nik_kepala_keluarga",
                table: "KartuKeluarga",
                column: "Nik_kepala_keluarga",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Ktp_Nik",
                table: "Ktp",
                column: "Nik",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AktaKelahiran");

            migrationBuilder.DropTable(name: "AnggotaKartuKeluarga");

            migrationBuilder.DropTable(name: "Ktp");

            migrationBuilder.DropTable(name: "KartuKeluarga");

            migrationBuilder.DropTable(name: "Orang");
        }
    }
}
