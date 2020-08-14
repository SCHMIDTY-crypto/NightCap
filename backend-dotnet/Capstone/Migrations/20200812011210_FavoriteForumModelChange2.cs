using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class FavoriteForumModelChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Forum");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Forum");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Forum");

            migrationBuilder.CreateTable(
                name: "user_forum_favorite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ForumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_forum_favorite", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_forum_favorite");

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Forum",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Forum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Forum",
                nullable: false,
                defaultValue: "");
        }
    }
}
