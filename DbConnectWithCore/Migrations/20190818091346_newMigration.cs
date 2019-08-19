using Microsoft.EntityFrameworkCore.Migrations;

namespace DbConnectWithCore.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopCustomers",
                columns: table => new
                {
                    shopcustomerId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    shopId = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCustomers", x => x.shopcustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    fName = table.Column<string>(nullable: true),
                    lName = table.Column<string>(nullable: true),
                    customerEmail = table.Column<string>(nullable: true),
                    ShopCustomersshopcustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customers_ShopCustomers_ShopCustomersshopcustomerId",
                        column: x => x.ShopCustomersshopcustomerId,
                        principalTable: "ShopCustomers",
                        principalColumn: "shopcustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    shopId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    shopName = table.Column<string>(nullable: true),
                    shopRate = table.Column<int>(nullable: true),
                    ShopCustomersshopcustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.shopId);
                    table.ForeignKey(
                        name: "FK_Shops_ShopCustomers_ShopCustomersshopcustomerId",
                        column: x => x.ShopCustomersshopcustomerId,
                        principalTable: "ShopCustomers",
                        principalColumn: "shopcustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    productName = table.Column<string>(nullable: true),
                    shopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Shops_shopId",
                        column: x => x.shopId,
                        principalTable: "Shops",
                        principalColumn: "shopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShopCustomersshopcustomerId",
                table: "Customers",
                column: "ShopCustomersshopcustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_shopId",
                table: "Products",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ShopCustomersshopcustomerId",
                table: "Shops",
                column: "ShopCustomersshopcustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "ShopCustomers");
        }
    }
}
