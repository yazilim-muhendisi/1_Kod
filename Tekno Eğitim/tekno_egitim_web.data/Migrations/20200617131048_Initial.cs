using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tekno_egitim_web.data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    kategori_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategori_ad = table.Column<string>(maxLength: 50, nullable: false),
                    Silme = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.kategori_id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    blog_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(maxLength: 200, nullable: false),
                    aciklama = table.Column<string>(nullable: false),
                    olusturulma = table.Column<DateTime>(type: "datetime", nullable: false),
                    imageUrl = table.Column<string>(maxLength: 200, nullable: true),
                    kategori_id = table.Column<int>(nullable: false),
                    blog_silme = table.Column<bool>(nullable: false),
                    Kategorilerkategori_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.blog_id);
                    table.ForeignKey(
                        name: "FK_Blog_Kategoriler_Kategorilerkategori_id",
                        column: x => x.Kategorilerkategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "kategori_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Haber",
                columns: table => new
                {
                    haber_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(maxLength: 200, nullable: false),
                    aciklama = table.Column<string>(nullable: false),
                    olusturulma = table.Column<DateTime>(type: "datetime", nullable: false),
                    imageUrl = table.Column<string>(maxLength: 200, nullable: true),
                    kategori_id = table.Column<int>(nullable: false),
                    haber_silme = table.Column<bool>(nullable: false),
                    Kategorilerkategori_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haber", x => x.haber_id);
                    table.ForeignKey(
                        name: "FK_Haber_Kategoriler_Kategorilerkategori_id",
                        column: x => x.Kategorilerkategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "kategori_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Makale",
                columns: table => new
                {
                    makale_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(maxLength: 200, nullable: false),
                    aciklama = table.Column<string>(nullable: false),
                    olusturulma = table.Column<DateTime>(type: "datetime", nullable: false),
                    imageUrl = table.Column<string>(maxLength: 200, nullable: true),
                    kategori_id = table.Column<int>(nullable: false),
                    makale_silme = table.Column<bool>(nullable: false),
                    Kategorilerkategori_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makale", x => x.makale_id);
                    table.ForeignKey(
                        name: "FK_Makale_Kategoriler_Kategorilerkategori_id",
                        column: x => x.Kategorilerkategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "kategori_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Not",
                columns: table => new
                {
                    not_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(maxLength: 200, nullable: true),
                    aciklama = table.Column<string>(nullable: true),
                    olusturulma = table.Column<DateTime>(type: "datetime", nullable: false),
                    imageUrl = table.Column<string>(maxLength: 200, nullable: true),
                    kategori_id = table.Column<int>(nullable: false),
                    not_silme = table.Column<bool>(nullable: false),
                    Kategorilerkategori_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Not", x => x.not_id);
                    table.ForeignKey(
                        name: "FK_Not_Kategoriler_Kategorilerkategori_id",
                        column: x => x.Kategorilerkategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "kategori_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    video_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(maxLength: 200, nullable: false),
                    aciklama = table.Column<string>(nullable: true),
                    olusturulma = table.Column<DateTime>(type: "datetime", nullable: false),
                    videoUrl = table.Column<string>(maxLength: 200, nullable: true),
                    kategori_id = table.Column<int>(nullable: false),
                    video_silme = table.Column<bool>(nullable: false),
                    Kategorilerkategori_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.video_id);
                    table.ForeignKey(
                        name: "FK_Video_Kategoriler_Kategorilerkategori_id",
                        column: x => x.Kategorilerkategori_id,
                        principalTable: "Kategoriler",
                        principalColumn: "kategori_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Kategorilerkategori_id",
                table: "Blog",
                column: "Kategorilerkategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Haber_Kategorilerkategori_id",
                table: "Haber",
                column: "Kategorilerkategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Makale_Kategorilerkategori_id",
                table: "Makale",
                column: "Kategorilerkategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Not_Kategorilerkategori_id",
                table: "Not",
                column: "Kategorilerkategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Kategorilerkategori_id",
                table: "Video",
                column: "Kategorilerkategori_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Haber");

            migrationBuilder.DropTable(
                name: "Makale");

            migrationBuilder.DropTable(
                name: "Not");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
