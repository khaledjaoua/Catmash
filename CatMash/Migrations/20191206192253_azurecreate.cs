using Microsoft.EntityFrameworkCore.Migrations;

namespace CatMash.Migrations
{
    public partial class azurecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "catmashid",
                table: "cats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cats",
                table: "cats",
                column: "CatMashId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cats",
                table: "cats");

            migrationBuilder.AddPrimaryKey(
                name: "catmashid",
                table: "cats",
                column: "CatMashId");
        }
    }
}
