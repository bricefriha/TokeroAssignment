using System;
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
                name: "FK_Setups_Data_UserDataid",
                table: "Setups");

            migrationBuilder.RenameColumn(
                name: "UserDataid",
                table: "Setups",
                newName: "UserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Setups_UserDataid",
                table: "Setups",
                newName: "IX_Setups_UserDataId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDataId",
                table: "Setups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Setups_Data_UserDataId",
                table: "Setups",
                column: "UserDataId",
                principalTable: "Data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setups_Data_UserDataId",
                table: "Setups");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "Setups",
                newName: "UserDataid");

            migrationBuilder.RenameIndex(
                name: "IX_Setups_UserDataId",
                table: "Setups",
                newName: "IX_Setups_UserDataid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDataid",
                table: "Setups",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Setups_Data_UserDataid",
                table: "Setups",
                column: "UserDataid",
                principalTable: "Data",
                principalColumn: "id");
        }
    }
}
