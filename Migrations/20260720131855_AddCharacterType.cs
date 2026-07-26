using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameCharacterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_TypeId",
                table: "Characters",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterType_TypeId",
                table: "Characters",
                column: "TypeId",
                principalTable: "CharacterType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterType_TypeId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterType");

            migrationBuilder.DropIndex(
                name: "IX_Characters_TypeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Characters");
        }
    }
}
