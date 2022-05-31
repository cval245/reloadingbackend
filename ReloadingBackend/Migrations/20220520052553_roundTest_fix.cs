using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class roundTest_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTests_RoundTestId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_RoundTestId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "RoundTestId",
                table: "Rounds");

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "RoundTests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoundTests_RoundId",
                table: "RoundTests",
                column: "RoundId",
                unique: true);

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
                name: "FK_RoundTests_Rounds_RoundId",
                table: "RoundTests");

            migrationBuilder.DropIndex(
                name: "IX_RoundTests_RoundId",
                table: "RoundTests");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "RoundTests");

            migrationBuilder.AddColumn<int>(
                name: "RoundTestId",
                table: "Rounds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_RoundTestId",
                table: "Rounds",
                column: "RoundTestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTests_RoundTestId",
                table: "Rounds",
                column: "RoundTestId",
                principalTable: "RoundTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
