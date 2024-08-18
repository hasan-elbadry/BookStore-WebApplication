using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class intialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Name", "dateOfBirth" },
                values: new object[,]
                {
                    { 1, "", "John", new DateTime(2000, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "Arnold", new DateTime(1890, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "Price", "Title", "imgUrl", "publicationDate" },
                values: new object[,]
                {
                    { 1, 1, "Technology", 0.0, "C# Programming Basics", "", new DateOnly(2020, 1, 1) },
                    { 2, 1, "Technology", 0.0, "Advanced C# Techniques", "", new DateOnly(2021, 2, 15) },
                    { 3, 2, "Technology", 0.0, "Learning Python", "", new DateOnly(2019, 3, 20) },
                    { 4, 2, "Technology", 0.0, "Mastering Python", "", new DateOnly(2018, 4, 5) },
                    { 5, 1, "Technology", 0.0, "Java for Beginners", "", new DateOnly(2017, 5, 10) },
                    { 6, 2, "Technology", 0.0, "Advanced Java Concepts", "", new DateOnly(2016, 6, 15) },
                    { 7, 1, "Technology", 0.0, "JavaScript Essentials", "", new DateOnly(2020, 7, 20) },
                    { 8, 2, "Technology", 0.0, "React.js Guide", "", new DateOnly(2021, 8, 25) },
                    { 9, 1, "Technology", 0.0, "Vue.js in Action", "", new DateOnly(2019, 9, 30) },
                    { 10, 2, "Technology", 0.0, "Angular for Professionals", "", new DateOnly(2018, 10, 5) },
                    { 11, 1, "Technology", 0.0, "Machine Learning with Python", "", new DateOnly(2017, 11, 10) },
                    { 12, 2, "Technology", 0.0, "Deep Learning Techniques", "", new DateOnly(2016, 12, 15) },
                    { 13, 1, "Technology", 0.0, "Data Science Essentials", "", new DateOnly(2020, 1, 20) },
                    { 14, 2, "Technology", 0.0, "Big Data Analytics", "", new DateOnly(2021, 2, 25) },
                    { 15, 1, "Technology", 0.0, "Cloud Computing Basics", "", new DateOnly(2019, 3, 30) },
                    { 16, 2, "Technology", 0.0, "AWS for Beginners", "", new DateOnly(2018, 4, 5) },
                    { 17, 1, "Technology", 0.0, "Azure in Action", "", new DateOnly(2017, 5, 10) },
                    { 18, 2, "Technology", 0.0, "GCP Fundamentals", "", new DateOnly(2016, 6, 15) },
                    { 19, 1, "Technology", 0.0, "Kubernetes Guide", "", new DateOnly(2020, 7, 20) },
                    { 20, 2, "Technology", 0.0, "Docker Deep Dive", "", new DateOnly(2021, 8, 25) },
                    { 21, 1, "Technology", 0.0, "Microservices Architecture", "", new DateOnly(2019, 9, 30) },
                    { 22, 2, "Technology", 0.0, "DevOps Essentials", "", new DateOnly(2018, 10, 5) },
                    { 23, 1, "Technology", 0.0, "Agile Development", "", new DateOnly(2017, 11, 10) },
                    { 24, 2, "Technology", 0.0, "Scrum Master Guide", "", new DateOnly(2016, 12, 15) },
                    { 25, 1, "Business", 0.0, "Project Management Basics", "", new DateOnly(2020, 1, 20) },
                    { 26, 2, "Business", 0.0, "Leadership Skills", "", new DateOnly(2021, 2, 25) },
                    { 27, 1, "Business", 0.0, "Effective Communication", "", new DateOnly(2019, 3, 30) },
                    { 28, 2, "Business", 0.0, "Negotiation Techniques", "", new DateOnly(2018, 4, 5) },
                    { 29, 1, "Business", 0.0, "Time Management", "", new DateOnly(2017, 5, 10) },
                    { 30, 2, "Business", 0.0, "Financial Analysis", "", new DateOnly(2016, 6, 15) },
                    { 31, 1, "Finance", 0.0, "Investing 101", "", new DateOnly(2020, 7, 20) },
                    { 32, 2, "Finance", 0.0, "Stock Market Basics", "", new DateOnly(2021, 8, 25) },
                    { 33, 1, "Finance", 0.0, "Real Estate Investment", "", new DateOnly(2019, 9, 30) },
                    { 34, 2, "Finance", 0.0, "Personal Finance Management", "", new DateOnly(2018, 10, 5) },
                    { 35, 1, "Finance", 0.0, "Retirement Planning", "", new DateOnly(2017, 11, 10) },
                    { 36, 2, "Finance", 0.0, "Insurance Essentials", "", new DateOnly(2016, 12, 15) },
                    { 37, 1, "Health", 0.0, "Health and Wellness", "", new DateOnly(2020, 1, 20) },
                    { 38, 2, "Health", 0.0, "Nutrition Basics", "", new DateOnly(2021, 2, 25) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
