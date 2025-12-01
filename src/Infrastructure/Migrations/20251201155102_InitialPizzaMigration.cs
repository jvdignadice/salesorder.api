using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPizzaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "PizzaType",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     pizza_type_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     ingredients = table.Column<string>(type: "bigint", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_PizzaType", x => x.Id);
                 });


            migrationBuilder.CreateTable(
                    name: "Pizza",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        pizza_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        pizza_type_id = table.Column<string>(type: "int", nullable: false),
                        size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Pizza", x => x.Id);
                    });
            migrationBuilder.CreateTable(
        name: "OrderDetails",
    columns: table => new
    {

        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
        order_id = table.Column<int>(type: "int", nullable: false),
        pizza_id = table.Column<string>(type: "int", nullable: false),
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
            // And same for Orders and OrderDetails

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaType");

            migrationBuilder.DropTable(
                name: "Pizza");
            migrationBuilder.DropTable(
                name: "OrderDetails");
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
