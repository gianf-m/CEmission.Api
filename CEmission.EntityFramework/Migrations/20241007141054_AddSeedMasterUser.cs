using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEmission.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedMasterUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO app_identityusers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, PasswordHash, PhoneNumber) VALUES ('{Guid.NewGuid()}', 'Master', 'MASTER', 'Master@Master.com', 'MASTER@MASTER.COM', '83f8aee68850ed14dbb807595c258bc87ea1dc11908badb38f281217330e05f0', '+580000000')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
