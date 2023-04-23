using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Migrations
{
    /// <inheritdoc />
    public partial class addRoleTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "499a0974-4d9c-42fb-8403-c66aabb6b640", null, "kassa", "kassa" },
                    { "8f6645bd-1353-43f3-b6b1-b13657688ce2", null, "manager", "manager" },
                    { "a3258c57-5f9b-4589-93e7-8d8bd8ee950a", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "30a89693-f92d-4288-991b-df0b15bcc66a", 0, "6e499218-de7e-43fc-99c9-7f9ffb02d97d", "admin@gmail.com", false, "admin", false, null, "admin@gmail.com", "admin", "AQAAAAIAAYagAAAAEN65FaB2qOHT2MOXrImjVGERn0Ell7fVx4XayJKfx1WzE3SvoGK4s+Ji+xTMmnmhww==", null, false, "", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3258c57-5f9b-4589-93e7-8d8bd8ee950a", "30a89693-f92d-4288-991b-df0b15bcc66a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "499a0974-4d9c-42fb-8403-c66aabb6b640");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6645bd-1353-43f3-b6b1-b13657688ce2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3258c57-5f9b-4589-93e7-8d8bd8ee950a", "30a89693-f92d-4288-991b-df0b15bcc66a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3258c57-5f9b-4589-93e7-8d8bd8ee950a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a89693-f92d-4288-991b-df0b15bcc66a");

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
    }
}
