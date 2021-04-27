using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePro.data.migration
{
    public partial class _005CastInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Cast_1");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_MovieId",
                table: "Cast_1",
                newName: "IX_Cast_1_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast_1",
                table: "Cast_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_1_Movie_MovieId",
                table: "Cast_1",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_1_Movie_MovieId",
                table: "Cast_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast_1",
                table: "Cast_1");

            migrationBuilder.RenameTable(
                name: "Cast_1",
                newName: "Cast");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_1_MovieId",
                table: "Cast",
                newName: "IX_Cast_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
