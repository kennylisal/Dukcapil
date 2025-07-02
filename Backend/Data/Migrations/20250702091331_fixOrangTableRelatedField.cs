using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixOrangTableRelatedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Tanggal_lahir", table: "AktaKelahiran");

            migrationBuilder.DropColumn(name: "Tempat_lahir", table: "AktaKelahiran");

            migrationBuilder.AlterColumn<bool>(
                name: "Is_active",
                table: "Ktp",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit"
            );

            migrationBuilder.AlterColumn<bool>(
                name: "Is_active",
                table: "AktaKelahiran",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Is_active",
                table: "Ktp",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true
            );

            migrationBuilder.AlterColumn<bool>(
                name: "Is_active",
                table: "AktaKelahiran",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true
            );

            migrationBuilder.AddColumn<DateOnly>(
                name: "Tanggal_lahir",
                table: "AktaKelahiran",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1)
            );

            migrationBuilder.AddColumn<string>(
                name: "Tempat_lahir",
                table: "AktaKelahiran",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: ""
            );
        }
    }
}
