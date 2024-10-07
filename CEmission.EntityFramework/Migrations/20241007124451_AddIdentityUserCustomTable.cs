using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEmission.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserCustomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(2500)", maxLength: 2500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_IdentityUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_App_IdentityUsers_Email",
                table: "App_IdentityUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_IdentityUsers_UserName",
                table: "App_IdentityUsers",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_IdentityUsers");
        }
    }
}
