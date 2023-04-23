using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Migrations
{
    /// <inheritdoc />
    public partial class addRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0440508d-0f87-4015-9112-1baef1bf1bfc", null, "admin", "admin" },
                    { "aa113d0e-a66b-4fe9-a79c-8a05fbb2e710", null, "manager", "manager" },
                    { "d340155b-82a9-40ca-a374-28e2fbcdf576", null, "kassa", "kassa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2102d2b8-9c4c-4323-a6fc-eb0a9f6b7d63", 0, "a9e2b42a-539f-42d4-aadd-1f813277d56e", "admin@gmail.com", false, "admin", false, null, "admin@gmail.com", "admin", "AQAAAAIAAYagAAAAEI2uRRWv0IubRWUwtURy5XY98IQouJJ9zbD0byhVxep9EpBgM4OBYexnq/ozkNvb2Q==", null, false, "", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0440508d-0f87-4015-9112-1baef1bf1bfc", "2102d2b8-9c4c-4323-a6fc-eb0a9f6b7d63" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa113d0e-a66b-4fe9-a79c-8a05fbb2e710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d340155b-82a9-40ca-a374-28e2fbcdf576");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0440508d-0f87-4015-9112-1baef1bf1bfc", "2102d2b8-9c4c-4323-a6fc-eb0a9f6b7d63" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0440508d-0f87-4015-9112-1baef1bf1bfc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2102d2b8-9c4c-4323-a6fc-eb0a9f6b7d63");
        }
    }
}
