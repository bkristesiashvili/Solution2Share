using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution2Share.Data.Migrations
{
    public partial class AddEmailFieldToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "microsoft_users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_microsoft_users_Email",
                table: "microsoft_users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_microsoft_users_Email",
                table: "microsoft_users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "microsoft_users");
        }
    }
}
