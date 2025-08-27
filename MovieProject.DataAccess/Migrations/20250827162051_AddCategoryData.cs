using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IMDB",
                table: "Movies",
                type: "decimal(4,2)",
                precision: 4,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Directors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Directors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "Description", "IsActive", "IsDeleted", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1d10cdbd-73de-4f8f-b1c1-0c679e6baf0e"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3153), "", true, false, "Horror", null },
                    { new Guid("204fcd24-81fe-461e-bee3-899ee1714ee8"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3135), "", true, false, "Comedy", null },
                    { new Guid("a36ac339-74cc-4c40-8de6-0bc72fcd4e0c"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3147), "", true, false, "Sci-fi", null },
                    { new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3131), "", true, false, "Action", null },
                    { new Guid("ec9c24e4-7bb7-48eb-a61f-a652c884716b"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3149), "", true, false, "Fantasy", null },
                    { new Guid("f68a6b18-6e50-41ec-b6e3-121f7619ce84"), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3151), "", true, false, "Documentary", null }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "BirthDate", "CreateAt", "Description", "FirstName", "IsActive", "IsDeleted", "LastName", "UpdateAt", "imageUrl" },
                values: new object[,]
                {
                    { new Guid("2d2aace2-f183-4b7c-90ef-4b4d284a0159"), new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3314), "American film director, producer, screenwriter, and actor.", "Martin", true, false, "Scorsese", null, null },
                    { new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"), new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 16, 20, 51, 289, DateTimeKind.Utc).AddTicks(3303), "British-American film director, producer, and screenwriter.", "Christopher", true, false, "Nolan", null, null },
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdafa56b-368b-4633-adb2-963aa41d0809"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("6e00e3aa-2aa2-4bad-ae37-25c16d34acc1"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "IMDB",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldPrecision: 4,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
