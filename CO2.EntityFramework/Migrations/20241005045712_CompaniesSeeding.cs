using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace CO2.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CompaniesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(CompanySeeding());
        }

        private string CompanySeeding() {
            StringBuilder vSql = new StringBuilder();
            string vCreationTime = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string vEmptyDate = new DateTime(1900, 01, 01).ToString("yyyy-MM-dd");
            vSql.AppendLine("INSERT INTO app_companies (Name, CreationTime, IsDeleted, DeletionTime)");
            vSql.AppendLine("VALUES");
            vSql.AppendLine($"('Dog CO', '{vCreationTime}', 0, '{vEmptyDate}'),");
            vSql.AppendLine($"('Cat CO', '{vCreationTime}', 0, '{vEmptyDate}'),");
            vSql.AppendLine($"('Worm CO', '{vCreationTime}', 0, '{vEmptyDate}'),");
            vSql.AppendLine($"('Fish CO', '{vCreationTime}', 0, '{vEmptyDate}')");
            return vSql.ToString(); 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
