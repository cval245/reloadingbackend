using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class range_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoundTests_Rounds_RoundId",
                table: "RoundTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoundTests",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoundTests",
                table: "RoundTests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTests_Rounds_RoundId",
                table: "RoundTests",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
