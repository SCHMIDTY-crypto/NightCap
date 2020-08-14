using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class MadeCommentIdAndPostIdNullableInVoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Votes",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Votes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Votes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Votes",
                newName: "Userid");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
