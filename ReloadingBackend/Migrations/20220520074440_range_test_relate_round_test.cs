using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class range_test_relate_round_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests");

            migrationBuilder.AlterColumn<int>(
                name: "RangeTestId",
                table: "RoundTests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId",
                principalTable: "RangeTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests");

            migrationBuilder.AlterColumn<int>(
                name: "RangeTestId",
                table: "RoundTests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_RangeTest_RangeTestId",
                table: "RoundTests",
                column: "RangeTestId",
                principalTable: "RangeTest",
                principalColumn: "Id");
        }
    }
}
