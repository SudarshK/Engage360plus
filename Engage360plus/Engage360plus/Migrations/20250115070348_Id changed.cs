using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Engage360plus.Migrations
{
    /// <inheritdoc />
    public partial class Idchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_ProductStatus_ProductStatusId",
                        column: x => x.ProductStatusId,
                        principalTable: "ProductStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Region" },
                values: new object[,]
                {
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b41"), "Pune0", "India0", "411072", "Pune0" },
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b42"), "Pune1", "India1", "411072", "Pune1" },
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b43"), "Pune2", "India2", "411072", "Pune2" },
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b44"), "Pune0", "India0", "411072", "Pune0" },
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b46"), "Pune0", "India0", "411072", "Pune0" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8d2ee75c-1d3f-4e54-9d3d-d9d4577dfedf"), "Paid" },
                    { new Guid("c2b30590-bc31-42de-a9b5-a3054eba5b45"), "Rejected" },
                    { new Guid("e89c34df-12c2-4dd1-a4a3-8740380f0f84"), "In Discussion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_AddressId",
                table: "CustomerDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_ProductStatusId",
                table: "CustomerDetails",
                column: "ProductStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ProductStatus");
        }
    }
}
