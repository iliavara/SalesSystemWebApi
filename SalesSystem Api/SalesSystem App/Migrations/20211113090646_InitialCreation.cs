using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesSystem_App.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new
                {
                    Client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_fname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Client_lname = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModels", x => x.Client_id);
                });

            migrationBuilder.CreateTable(
                name: "SellerModels",
                columns: table => new
                {
                    Seller_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seller_boss_id = table.Column<int>(type: "int", nullable: true),
                    Seller_fname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Seller_lname = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerModels", x => x.Seller_id);
                });

            migrationBuilder.CreateTable(
                name: "OrderModels",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_parent_id = table.Column<int>(type: "int", nullable: true),
                    Clients_Orders_FK1 = table.Column<int>(type: "int", nullable: true),
                    Sellers_Orders_FK2 = table.Column<int>(type: "int", nullable: true),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModels", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_OrderModels_ClientModels_Clients_Orders_FK1",
                        column: x => x.Clients_Orders_FK1,
                        principalTable: "ClientModels",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderModels_SellerModels_Sellers_Orders_FK2",
                        column: x => x.Sellers_Orders_FK2,
                        principalTable: "SellerModels",
                        principalColumn: "Seller_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_Clients_Orders_FK1",
                table: "OrderModels",
                column: "Clients_Orders_FK1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModels_Sellers_Orders_FK2",
                table: "OrderModels",
                column: "Sellers_Orders_FK2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderModels");

            migrationBuilder.DropTable(
                name: "ClientModels");

            migrationBuilder.DropTable(
                name: "SellerModels");
        }
    }
}
