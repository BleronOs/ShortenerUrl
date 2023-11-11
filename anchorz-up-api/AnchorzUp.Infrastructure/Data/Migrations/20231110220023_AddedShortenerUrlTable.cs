using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnchorzUp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedShortenerUrlTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shortener_url",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    originalurl = table.Column<string>(name: "original_url", type: "text", nullable: false),
                    shortalias = table.Column<string>(name: "short_alias", type: "text", nullable: false),
                    createddatetime = table.Column<DateTime>(name: "created_date_time", type: "timestamp without time zone", nullable: false),
                    expirationdatetime = table.Column<DateTime>(name: "expiration_date_time", type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shortener_url", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shortener_url");
        }
    }
}
