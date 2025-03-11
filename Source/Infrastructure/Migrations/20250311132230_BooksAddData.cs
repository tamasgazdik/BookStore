using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BooksAddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "J.D. Salinger", new DateOnly(1951, 7, 16), "The Catcher in the Rye" },
                    { 2, "Harper Lee", new DateOnly(1960, 7, 11), "To Kill a Mockingbird" },
                    { 3, "George Orwell", new DateOnly(1949, 6, 8), "1984" },
                    { 4, "Jane Austen", new DateOnly(1813, 1, 28), "Pride and Prejudice" },
                    { 5, "F. Scott Fitzgerald", new DateOnly(1925, 4, 10), "The Great Gatsby" },
                    { 6, "Herman Melville", new DateOnly(1851, 10, 18), "Moby-Dick" },
                    { 7, "Leo Tolstoy", new DateOnly(1869, 1, 1), "War and Peace" },
                    { 8, "J.R.R. Tolkien", new DateOnly(1937, 9, 21), "The Hobbit" },
                    { 9, "Fyodor Dostoevsky", new DateOnly(1866, 1, 1), "Crime and Punishment" },
                    { 10, "Homer", new DateOnly(701, 1, 1), "The Odyssey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
