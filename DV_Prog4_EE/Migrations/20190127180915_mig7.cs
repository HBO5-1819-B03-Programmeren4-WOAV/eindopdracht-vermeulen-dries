using Microsoft.EntityFrameworkCore.Migrations;

namespace DV_Prog4_EE.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_AppUserId",
                table: "Event",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_AppUserId",
                table: "Event",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_AppUserId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_AppUserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Event");
        }
    }
}
