using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class remove_weather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RangeTest",
                table: "RangeTest");

            migrationBuilder.RenameTable(
                name: "RangeTest",
                newName: "RangeTests");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "RangeTests",
                newName: "Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RangeTests",
                table: "RangeTests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_RangeTests_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId",
                principalTable: "RangeTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_RangeTests_RangeTestId",
                table: "RoundTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RangeTests",
                table: "RangeTests");

            migrationBuilder.RenameTable(
                name: "RangeTests",
                newName: "RangeTest");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "RangeTest",
                newName: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RangeTest",
                table: "RangeTest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId",
                principalTable: "RangeTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
