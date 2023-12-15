using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Migrations
{
    /// <inheritdoc />
    public partial class AddConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_users_FromUserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Messages",
                newName: "from_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                newName: "IX_Messages_from_user_id");

            migrationBuilder.AddForeignKey(
                name: "messages_from_user_id_fkey",
                table: "Messages",
                column: "from_user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "messages_from_user_id_fkey",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "from_user_id",
                table: "Messages",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_from_user_id",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_users_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
