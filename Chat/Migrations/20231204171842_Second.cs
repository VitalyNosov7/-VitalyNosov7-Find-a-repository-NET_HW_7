using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                table: "Messages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_users_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_users_FromUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Messages");
        }
    }
}
