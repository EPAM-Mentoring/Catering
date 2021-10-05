using Microsoft.EntityFrameworkCore.Migrations;

namespace Catering.DAL.Migrations
{
    public partial class BasketItemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealBasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealQuantity = table.Column<int>(type: "int", nullable: false),
                    MealPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerBasketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealBasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealBasketItems_CustomerBaskets_CustomerBasketId",
                        column: x => x.CustomerBasketId,
                        principalTable: "CustomerBaskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealOrdered_MealItemId = table.Column<int>(type: "int", nullable: true),
                    MealOrdered_MealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealOrdered_MealPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealOrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealBasketItems_CustomerBasketId",
                table: "MealBasketItems",
                column: "CustomerBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrderItems_OrderId",
                table: "MealOrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealBasketItems");

            migrationBuilder.DropTable(
                name: "MealOrderItems");
        }
    }
}
