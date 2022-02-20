using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularTest.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "Title" },
                values: new object[] { 1, "text1", "title1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "Title" },
                values: new object[] { 2, "text2", "title2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "Title" },
                values: new object[] { 3, "text3", "title3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
