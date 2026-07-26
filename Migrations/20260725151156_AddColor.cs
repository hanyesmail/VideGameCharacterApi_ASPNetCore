using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameCharacterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterType_TypeId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterType",
                table: "CharacterType");

            migrationBuilder.RenameTable(
                name: "CharacterType",
                newName: "CharacterTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterTypes",
                table: "CharacterTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CharacterColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterColors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterTypes_TypeId",
                table: "Characters",
                column: "TypeId",
                principalTable: "CharacterTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterTypes_TypeId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterTypes",
                table: "CharacterTypes");

            migrationBuilder.RenameTable(
                name: "CharacterTypes",
                newName: "CharacterType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterType",
                table: "CharacterType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterType_TypeId",
                table: "Characters",
                column: "TypeId",
                principalTable: "CharacterType",
                principalColumn: "Id");
        }
    }
}
