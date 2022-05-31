using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReloadingBackend.Migrations
{
    public partial class roundTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundTestId",
                table: "Rounds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoundTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Velocity = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundTests", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTests_RoundTestId",
                table: "Rounds");

            migrationBuilder.DropTable(
                name: "RoundTests");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_RoundTestId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "RoundTestId",
                table: "Rounds");
        }
    }
}
