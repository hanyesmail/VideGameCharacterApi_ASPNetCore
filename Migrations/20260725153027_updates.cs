using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameCharacterApi.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ColorId",
                table: "Characters",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterColors_ColorId",
                table: "Characters",
                column: "ColorId",
                principalTable: "CharacterColors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterColors_ColorId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ColorId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Characters");
        }
    }
}
