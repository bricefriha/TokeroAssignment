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
                name: "FK_Orders_Data_UserDataid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserDataid",
                table: "Orders",
                newName: "UserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserDataid",
                table: "Orders",
                newName: "IX_Orders_UserDataId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDataId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AmountToken",
                table: "Balances",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Data_UserDataId",
                table: "Orders",
                column: "UserDataId",
                principalTable: "Data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Data_UserDataId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "Orders",
                newName: "UserDataid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserDataId",
                table: "Orders",
                newName: "IX_Orders_UserDataid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDataid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "AmountToken",
                table: "Balances",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Data_UserDataid",
                table: "Orders",
                column: "UserDataid",
                principalTable: "Data",
                principalColumn: "id");
        }
    }
}
