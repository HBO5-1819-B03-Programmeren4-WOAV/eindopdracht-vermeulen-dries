using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DV_Prog4_EE.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "AdminIdId",
                table: "Group",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true),
                    User1Id = table.Column<int>(nullable: true),
                    User2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_User_User1Id",
                        column: x => x.User1Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_User_User2Id",
                        column: x => x.User2Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_AdminIdId",
                table: "Group",
                column: "AdminIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User1Id",
                table: "Friends",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User2Id",
                table: "Friends",
                column: "User2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_AdminIdId",
                table: "Group",
                column: "AdminIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_AdminIdId",
                table: "Group");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Group_AdminIdId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "AdminIdId",
                table: "Group");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Group",
                nullable: true);
        }
    }
}
