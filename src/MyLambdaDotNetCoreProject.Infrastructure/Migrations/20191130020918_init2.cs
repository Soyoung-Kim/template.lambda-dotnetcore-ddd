using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLambdaDotNetCoreProject.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity1s",
                table: "Entity1s");

            migrationBuilder.RenameTable(
                name: "Entity1s",
                newName: "Entity1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity1",
                table: "Entity1",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity1",
                table: "Entity1");

            migrationBuilder.RenameTable(
                name: "Entity1",
                newName: "Entity1s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity1s",
                table: "Entity1s",
                column: "Id");
        }
    }
}
