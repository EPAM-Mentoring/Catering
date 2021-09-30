using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catering.DAL.Migrations
{
    public partial class UpdateRestaurantEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedTime",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "ClosedTime",
                table: "FoodShops",
                newName: "CloseTime");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OpenTime",
                table: "Restaurants",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<decimal>(
                name: "BookingPricePerDay",
                table: "Restaurants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CloseTime",
                table: "Restaurants",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForBooking",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodShops",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "FoodShops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingPricePerDay",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsAvailableForBooking",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FoodShops");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "FoodShops");

            migrationBuilder.RenameColumn(
                name: "CloseTime",
                table: "FoodShops",
                newName: "ClosedTime");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OpenTime",
                table: "Restaurants",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ClosedTime",
                table: "Restaurants",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
