using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.PetShop.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetShops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetShops", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PetShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_PetShops_PetShopID",
                        column: x => x.PetShopID,
                        principalTable: "PetShops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryPerMonth = table.Column<double>(type: "float", maxLength: 15, nullable: false),
                    EmployeeType = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    PetShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_PetShops_PetShopID",
                        column: x => x.PetShopID,
                        principalTable: "PetShops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetFoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    PetFoodPrice = table.Column<double>(type: "float", nullable: false),
                    PetFoodCost = table.Column<double>(type: "float", nullable: false),
                    PetShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetFoods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PetFoods_PetShops_PetShopID",
                        column: x => x.PetShopID,
                        principalTable: "PetShops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    PetShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pets_PetShops_PetShopID",
                        column: x => x.PetShopID,
                        principalTable: "PetShops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetPrice = table.Column<double>(type: "float", nullable: false),
                    PetFoodQty = table.Column<double>(type: "float", nullable: false),
                    PetFoodPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    PetShopID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PetID = table.Column<int>(type: "int", nullable: false),
                    PetFoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_PetShops_PetShopID",
                        column: x => x.PetShopID,
                        principalTable: "PetShops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PetShopID",
                table: "Customers",
                column: "PetShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PetShopID",
                table: "Employees",
                column: "PetShopID");

            migrationBuilder.CreateIndex(
                name: "IX_PetFoods_PetShopID",
                table: "PetFoods",
                column: "PetShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetShopID",
                table: "Pets",
                column: "PetShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PetShopID",
                table: "Transactions",
                column: "PetShopID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PetFoods");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "PetShops");
        }
    }
}
