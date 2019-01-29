using Microsoft.EntityFrameworkCore.Migrations;

namespace DV_Prog4_EE.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Group_OwnerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_User1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_User_User2Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_User_AppUserId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Group_GroupId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Event_EventId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_User_GroupId",
                table: "Users",
                newName: "IX_Users_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_User_EventId",
                table: "Users",
                newName: "IX_Users_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Groups_OwnerId",
                table: "Event",
                column: "OwnerId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_User1Id",
                table: "Friends",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_User2Id",
                table: "Friends",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Users_AppUserId",
                table: "Invitation",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Groups_GroupId",
                table: "Invitation",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Event_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Groups_OwnerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_User1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_User2Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Users_AppUserId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Groups_GroupId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Event_EventId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId",
                table: "User",
                newName: "IX_User_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_EventId",
                table: "User",
                newName: "IX_User_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Group_OwnerId",
                table: "Event",
                column: "OwnerId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_User1Id",
                table: "Friends",
                column: "User1Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_User_User2Id",
                table: "Friends",
                column: "User2Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_User_AppUserId",
                table: "Invitation",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Group_GroupId",
                table: "Invitation",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Event_EventId",
                table: "User",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
