using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changes = table.Column<double>(type: "float", nullable: true),
                    PriceUsd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CmcId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changes = table.Column<double>(type: "float", nullable: true),
                    PriceUsd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tokenid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Token_Tokenid",
                        column: x => x.Tokenid,
                        principalTable: "Token",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenShare",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSetup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pourcentage = table.Column<double>(type: "float", nullable: true),
                    FixAmountUSD = table.Column<double>(type: "float", nullable: true),
                    Tokenid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DcaSetupid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenShare", x => x.id);
                    table.ForeignKey(
                        name: "FK_TokenShare_Setups_DcaSetupid",
                        column: x => x.DcaSetupid,
                        principalTable: "Setups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TokenShare_Token_Tokenid",
                        column: x => x.Tokenid,
                        principalTable: "Token",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Tokenid",
                table: "Orders",
                column: "Tokenid");

            migrationBuilder.CreateIndex(
                name: "IX_TokenShare_DcaSetupid",
                table: "TokenShare",
                column: "DcaSetupid");

            migrationBuilder.CreateIndex(
                name: "IX_TokenShare_Tokenid",
                table: "TokenShare",
                column: "Tokenid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TokenShare");

            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
