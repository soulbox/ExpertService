using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpertService.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosya",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    TCNO = table.Column<long>(nullable: false),
                    Adı = table.Column<string>(nullable: true),
                    Soyadı = table.Column<string>(nullable: true),
                    DosyaNo = table.Column<string>(nullable: true),
                    Açıklama = table.Column<string>(nullable: true),
                    DavaTarihi = table.Column<DateTime>(nullable: false),
                    ZamanAsimi = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AnaDosyaID = table.Column<int>(nullable: true),
                    CompleteDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosya_Dosya_AnaDosyaID",
                        column: x => x.AnaDosyaID,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dosya_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalismaDonemi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    KıdemAlındı = table.Column<bool>(nullable: false),
                    ihbarAlındı = table.Column<bool>(nullable: false),
                    FazlaMesaiAlındı = table.Column<bool>(nullable: false),
                    DosyaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaDonemi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalismaDonemi_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talepler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    DosyaId = table.Column<int>(nullable: false),
                    Hesapla = table.Column<bool>(nullable: false),
                    TalepTipi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talepler_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UcretBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    DosyaId = table.Column<int>(nullable: false),
                    Açıklama = table.Column<int>(nullable: false),
                    Tutar = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UcretBilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UcretBilgileri_Dosya_DosyaId",
                        column: x => x.DosyaId,
                        principalTable: "Dosya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZamanCizelgesi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Gün = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    RestTime = table.Column<TimeSpan>(nullable: false),
                    CalismaDonemiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamanCizelgesi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZamanCizelgesi_CalismaDonemi_CalismaDonemiId",
                        column: x => x.CalismaDonemiId,
                        principalTable: "CalismaDonemi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Adres", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Password", "Surname", "Tel", "UserName", "isActive" },
                values: new object[] { 1, "admin", new DateTime(2020, 6, 19, 15, 15, 0, 671, DateTimeKind.Utc).AddTicks(9246), null, new DateTime(2020, 6, 19, 15, 15, 13, 278, DateTimeKind.Utc).AddTicks(463), "admin", "admin", "admin", "admin", "admin", true });

            migrationBuilder.CreateIndex(
                name: "IX_CalismaDonemi_DosyaId",
                table: "CalismaDonemi",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_AnaDosyaID",
                table: "Dosya",
                column: "AnaDosyaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dosya_UserId",
                table: "Dosya",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Talepler_DosyaId",
                table: "Talepler",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_UcretBilgileri_DosyaId",
                table: "UcretBilgileri",
                column: "DosyaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZamanCizelgesi_CalismaDonemiId",
                table: "ZamanCizelgesi",
                column: "CalismaDonemiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talepler");

            migrationBuilder.DropTable(
                name: "UcretBilgileri");

            migrationBuilder.DropTable(
                name: "ZamanCizelgesi");

            migrationBuilder.DropTable(
                name: "CalismaDonemi");

            migrationBuilder.DropTable(
                name: "Dosya");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
