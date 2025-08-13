using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserDataid",
                table: "Setups",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserDataid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Changes = table.Column<double>(type: "float", nullable: true),
                    PriceUsd = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tokenid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountUSD = table.Column<double>(type: "float", nullable: true),
                    AmountToken = table.Column<double>(type: "float", nullable: true),
                    UserDataid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Balance_Data_UserDataid",
                        column: x => x.UserDataid,
                        principalTable: "Data",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Balance_Token_Tokenid",
                        column: x => x.Tokenid,
                        principalTable: "Token",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setups_UserDataid",
                table: "Setups",
                column: "UserDataid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserDataid",
                table: "Orders",
                column: "UserDataid");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_Tokenid",
                table: "Balance",
                column: "Tokenid");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_UserDataid",
                table: "Balance",
                column: "UserDataid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Data_UserDataid",
                table: "Orders",
                column: "UserDataid",
                principalTable: "Data",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Setups_Data_UserDataid",
                table: "Setups",
                column: "UserDataid",
                principalTable: "Data",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Data_UserDataid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Setups_Data_UserDataid",
                table: "Setups");

            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Setups_UserDataid",
                table: "Setups");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserDataid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserDataid",
                table: "Setups");

            migrationBuilder.DropColumn(
                name: "UserDataid",
                table: "Orders");
        }
    }
}
