using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TokeroDBMigData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Token_Tokenid",
                table: "Balances");

            migrationBuilder.RenameColumn(
                name: "Tokenid",
                table: "Balances",
                newName: "TokenId");

            migrationBuilder.RenameIndex(
                name: "IX_Balances_Tokenid",
                table: "Balances",
                newName: "IX_Balances_TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Token_TokenId",
                table: "Balances",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Token_TokenId",
                table: "Balances");

            migrationBuilder.RenameColumn(
                name: "TokenId",
                table: "Balances",
                newName: "Tokenid");

            migrationBuilder.RenameIndex(
                name: "IX_Balances_TokenId",
                table: "Balances",
                newName: "IX_Balances_Tokenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Token_Tokenid",
                table: "Balances",
                column: "Tokenid",
                principalTable: "Token",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
