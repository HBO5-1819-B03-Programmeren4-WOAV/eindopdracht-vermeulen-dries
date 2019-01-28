using Microsoft.EntityFrameworkCore.Migrations;

namespace DV_Prog4_EE.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_EventId",
                table: "User",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Event_EventId",
                table: "User",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Event_EventId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EventId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "User");

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
    }
}
