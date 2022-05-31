using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class range_test_relate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTest_Rounds_RoundId",
                table: "RoundTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoundTest",
                table: "RoundTest");

            migrationBuilder.RenameTable(
                name: "RoundTest",
                newName: "RoundTests");

            migrationBuilder.RenameIndex(
                name: "IX_RoundTest_RoundId",
                table: "RoundTests",
                newName: "IX_RoundTests_RoundId");

            migrationBuilder.AddColumn<int>(
                name: "RangeTestId",
                table: "RoundTests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoundTests",
                table: "RoundTests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RangeTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeTest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundTests_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId",
                principalTable: "RangeTest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_Rounds_RoundId",
                table: "RoundTests",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_Rounds_RoundId",
                table: "RoundTests");

            migrationBuilder.DropTable(
                name: "RangeTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoundTests",
                table: "RoundTests");

            migrationBuilder.DropIndex(
                name: "IX_RoundTests_RangeTestId",
                table: "RoundTests");

            migrationBuilder.DropColumn(
                name: "RangeTestId",
                table: "RoundTests");

            migrationBuilder.RenameTable(
                name: "RoundTests",
                newName: "RoundTest");

            migrationBuilder.RenameIndex(
                name: "IX_RoundTests_RoundId",
                table: "RoundTest",
                newName: "IX_RoundTest_RoundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoundTest",
                table: "RoundTest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTest_Rounds_RoundId",
                table: "RoundTest",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
