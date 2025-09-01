using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserAndClaimTablesCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d10cdbd-73de-4f8f-b1c1-0c679e6baf0e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("204fcd24-81fe-461e-bee3-899ee1714ee8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a36ac339-74cc-4c40-8de6-0bc72fcd4e0c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec9c24e4-7bb7-48eb-a61f-a652c884716b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f68a6b18-6e50-41ec-b6e3-121f7619ce84"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("2d2aace2-f183-4b7c-90ef-4b4d284a0159"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("90a57c3d-5d8d-499e-81c6-8b6355781e90"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("9ead7742-3a96-4e1b-8969-f97fc1f401d6"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("d93b273f-3c4d-465c-bfa0-1693820ba43f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0182e892-6cf0-481c-8ba2-df832db5b333"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4468d1ca-5808-47f2-8067-53323d027662"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("8468f525-e0d6-4609-beb6-ba02327f69aa"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"),
                columns: new[] { "CreateAt", "Description" },
                values: new object[] { new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5437), null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "Description", "IsActive", "IsDeleted", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("47267998-5679-4a59-95a8-a034a451899a"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5483), null, true, false, "Documentary", null },
                    { new Guid("5b4cc0ce-04fc-48fa-87d5-9f078ad014e4"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5443), null, true, false, "Comedy", null },
                    { new Guid("8ebe0412-a594-4d2b-9f1c-438199e5d260"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5486), null, true, false, "Horror", null },
                    { new Guid("de92eed4-b253-4786-8c69-e94f6801aa52"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5449), null, true, false, "Fantasy", null },
                    { new Guid("fdb5204c-f6df-46e7-bfa9-03c255296193"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5446), null, true, false, "Sci-fi", null }
                });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"),
                column: "CreateAt",
                value: new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "BirthDate", "CreateAt", "Description", "FirstName", "IsActive", "IsDeleted", "LastName", "UpdateAt", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("3906ffcc-6ef3-484e-a9d5-20881942bf48"), new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5635), "American film director, producer, screenwriter, and actor.", "Martin", true, false, "Scorsese", null, null },
                    { new Guid("69da5629-e20d-4191-b238-102211c24f60"), new DateTime(1954, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5641), "Canadian filmmaker and environmental advocate.", "James", true, false, "Cameron", null, null },
                    { new Guid("9a2d3ac6-56b5-48e0-87d2-f851f8dad0a3"), new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5628), "American film director, producer, and screenwriter.", "Steven", true, false, "Spielberg", null, null },
                    { new Guid("ad5c3344-1013-4889-8dbd-081a3b261658"), new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5638), "American filmmaker, actor, and screenwriter.", "Quentin", true, false, "Tarantino", null, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CreateAt", "Description", "DirectorId", "IMDB", "ImageUrl", "IsActive", "IsDeleted", "Name", "PublishDate", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0b6da30c-066c-40aa-93b7-9d3a1a333cd0"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5683), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 8.6m, null, true, false, "Interstellar", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("223f83d4-2257-4ae7-bf0d-9664b5842556"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5678), "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 9.0m, null, true, false, "The Dark Knight", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("e8e24ba8-8618-4129-9f38-f0700f183050"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 9, 1, 16, 24, 59, 213, DateTimeKind.Utc).AddTicks(5664), "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 8.8m, null, true, false, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47267998-5679-4a59-95a8-a034a451899a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b4cc0ce-04fc-48fa-87d5-9f078ad014e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ebe0412-a594-4d2b-9f1c-438199e5d260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("de92eed4-b253-4786-8c69-e94f6801aa52"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdb5204c-f6df-46e7-bfa9-03c255296193"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("3906ffcc-6ef3-484e-a9d5-20881942bf48"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("69da5629-e20d-4191-b238-102211c24f60"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("9a2d3ac6-56b5-48e0-87d2-f851f8dad0a3"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("ad5c3344-1013-4889-8dbd-081a3b261658"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0b6da30c-066c-40aa-93b7-9d3a1a333cd0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("223f83d4-2257-4ae7-bf0d-9664b5842556"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e8e24ba8-8618-4129-9f38-f0700f183050"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"),
                columns: new[] { "CreateAt", "Description" },
                values: new object[] { new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3131), "" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "Description", "IsActive", "IsDeleted", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1d10cdbd-73de-4f8f-b1c1-0c679e6baf0e"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3153), "", true, false, "Horror", null },
                    { new Guid("204fcd24-81fe-461e-bee3-899ee1714ee8"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3135), "", true, false, "Comedy", null },
                    { new Guid("a36ac339-74cc-4c40-8de6-0bc72fcd4e0c"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3147), "", true, false, "Sci-fi", null },
                    { new Guid("ec9c24e4-7bb7-48eb-a61f-a652c884716b"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3149), "", true, false, "Fantasy", null },
                    { new Guid("f68a6b18-6e50-41ec-b6e3-121f7619ce84"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3151), "", true, false, "Documentary", null }
                });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"),
                column: "CreateAt",
                value: new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "BirthDate", "CreateAt", "Description", "FirstName", "IsActive", "IsDeleted", "LastName", "UpdateAt", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("2d2aace2-f183-4b7c-90ef-4b4d284a0159"), new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3314), "American film director, producer, screenwriter, and actor.", "Martin", true, false, "Scorsese", null, null },
                    { new Guid("90a57c3d-5d8d-499e-81c6-8b6355781e90"), new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3316), "American filmmaker, actor, and screenwriter.", "Quentin", true, false, "Tarantino", null, null },
                    { new Guid("9ead7742-3a96-4e1b-8969-f97fc1f401d6"), new DateTime(1954, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3318), "Canadian filmmaker and environmental advocate.", "James", true, false, "Cameron", null, null },
                    { new Guid("d93b273f-3c4d-465c-bfa0-1693820ba43f"), new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3311), "American film director, producer, and screenwriter.", "Steven", true, false, "Spielberg", null, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CreateAt", "Description", "DirectorId", "IMDB", "ImageUrl", "IsActive", "IsDeleted", "Name", "PublishDate", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0182e892-6cf0-481c-8ba2-df832db5b333"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3354), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 8.6m, null, true, false, "Interstellar", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("4468d1ca-5808-47f2-8067-53323d027662"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3350), "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 9.0m, null, true, false, "The Dark Knight", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("8468f525-e0d6-4609-beb6-ba02327f69aa"), new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3339), "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), 8.8m, null, true, false, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }
    }
}
