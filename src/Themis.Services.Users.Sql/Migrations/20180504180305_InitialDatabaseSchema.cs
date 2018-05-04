using Microsoft.EntityFrameworkCore.Migrations;

namespace Themis.Services.Users.Sql.Migrations
{
    public partial class InitialDatabaseSchema : Migration
    {
        private const string SeedScript =
                "INSERT INTO [dbo].[Users] ([DisplayName], [FirstName], [LastName], [EmailAddress], [Country], [City], [Street])\r\nVALUES (\'Tom Kerkhove\', \'Tom\', \'Kerkhove\', \'Tom.Kerkhove@codit.eu\', \'Belgium\', \'Ghent\', \'Gaston Crommenlaan 14\'),\r\n       (\'BillBracket\',\'Bill\', \'Bracket\', \'Bill.Bracket@codit.eu\', \'Belgium\', \'Ghent\', \'Gaston Crommenlaan 14\')";

        private const string GetUserStoredProcedureScript = @"CREATE PROCEDURE GetUserInformation
	                                                                @emailAddress nvarchar(max) 
                                                                AS
                                                                BEGIN
	                                                                SELECT * FROM Users WHERE LOWER(EmailAddress) = LOWER(@emailAddress)
                                                                END";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    EmailAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.EmailAddress); });

            migrationBuilder.Sql(GetUserStoredProcedureScript);
            migrationBuilder.Sql(SeedScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Users");
        }
    }
}