using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_PizzaType_PizzaTypeId",
                table: "Pizza");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PizzaType_TempId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "PizzaTypeId",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "PizzaType",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PizzaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ingredients",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "pizza_id",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Pizza",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaType",
                table: "PizzaType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    pizza_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaType",
                table: "PizzaType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "category",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ingredients",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "name",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "pizza_type_id",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "pizza_id",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "pizza_type_id",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Pizza");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PizzaType",
                newName: "TempId");

            migrationBuilder.AlterColumn<int>(
                name: "TempId",
                table: "PizzaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PizzaTypeId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PizzaType_TempId",
                table: "PizzaType",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_PizzaType_PizzaTypeId",
                table: "Pizza",
                column: "PizzaTypeId",
                principalTable: "PizzaType",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
