using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Engage360plus.Migrations
{
    /// <inheritdoc />
    public partial class NavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AddressesAddressId = table.Column<int>(type: "int", nullable: false),
                    ProductStatusStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_Addresses_AddressesAddressId",
                        column: x => x.AddressesAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_ProductStatuses_ProductStatusStatusId",
                        column: x => x.ProductStatusStatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "Pune0", "India0", "411072", "Pune0" },
                    { 2, "Pune1", "India1", "411072", "Pune1" },
                    { 3, "Pune2", "India2", "411072", "Pune2" },
                    { 4, "Pune0", "India0", "411072", "Pune0" },
                    { 5, "Pune0", "India0", "411072", "Pune0" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "In Discussion" },
                    { 2, "Paid" },
                    { 3, "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_AddressesAddressId",
                table: "CustomerDetails",
                column: "AddressesAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_ProductStatusStatusId",
                table: "CustomerDetails",
                column: "ProductStatusStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ProductStatuses");
        }
    }
}
