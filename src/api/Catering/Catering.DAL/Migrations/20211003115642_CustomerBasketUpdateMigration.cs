using Microsoft.EntityFrameworkCore.Migrations;

namespace Catering.DAL.Migrations
{
    public partial class CustomerBasketUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethodId",
                table: "CustomerBaskets",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                table: "CustomerBaskets");
        }
    }
}
