using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Session = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41a85ed5-793d-48f3-b42d-2df20ec08626"), "Beyaz Eşya" },
                    { new Guid("7c9cbfed-26f3-4063-9d41-0306f1eae424"), "Elektronik" },
                    { new Guid("85c50918-6ce0-4531-b308-2e524ac63c3a"), "Kozmetik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Password", "Session", "UserName" },
                values: new object[,]
                {
                    { new Guid("1edd49c1-c4ad-493b-8b9e-25609cbeea18"), 18, "First UserName", "First LastName", "24c9e15e52afc47c225b757e7bee1f9d", null, "user1" },
                    { new Guid("e44e664a-bb62-486d-984b-5aab43837d58"), 43, "Second UserName", "Second LastName", "7e58d63b60197ceb55a1c487989a3720", null, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("d09978fd-3031-40dd-b6fb-bcc0cc368572"), new DateTime(2022, 5, 14, 15, 36, 29, 613, DateTimeKind.Local).AddTicks(8165), "user2 second order", new Guid("e44e664a-bb62-486d-984b-5aab43837d58") },
                    { new Guid("f188baed-84d3-423e-86fe-a442a2f5988f"), new DateTime(2022, 5, 14, 15, 36, 29, 613, DateTimeKind.Local).AddTicks(8157), "user1 first order", new Guid("1edd49c1-c4ad-493b-8b9e-25609cbeea18") },
                    { new Guid("fe63088f-6578-4ffe-aa9e-bf47bcc5fc21"), new DateTime(2022, 5, 14, 15, 36, 29, 613, DateTimeKind.Local).AddTicks(8163), "user2 first order", new Guid("e44e664a-bb62-486d-984b-5aab43837d58") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0df308d6-1d62-49f8-b87d-45121a8fb087"), new Guid("7c9cbfed-26f3-4063-9d41-0306f1eae424"), new Guid("17e2c381-beb8-4419-b821-10c9c4d111b4"), "Samsung Xpress Sl M2020-2070Fw - Mlt D111S Muadil Toneri - Çipli", 1300.13m },
                    { new Guid("a4436498-5dd2-49f4-a83c-850c8e46eaab"), new Guid("41a85ed5-793d-48f3-b42d-2df20ec08626"), new Guid("a7e827ed-3a8b-4213-bcfa-1b66819d1739"), "Grundig GWM 91014 A 9 kg 1000 Devir Bluetooth Bağlantılı Çamaşır Makinesi", 1300.13m },
                    { new Guid("b2ea5779-f229-4c45-b565-553dd05aa079"), new Guid("7c9cbfed-26f3-4063-9d41-0306f1eae424"), new Guid("11ca2893-a0fe-4286-bb15-bad66730e45e"), "HP Smart Tank 519 3YW73A Wi-Fi + Fotokopi + Tarayıcı Renkli", 1300.13m },
                    { new Guid("f5d2ca2d-df60-421b-9a2b-2c957c258eb3"), new Guid("7c9cbfed-26f3-4063-9d41-0306f1eae424"), new Guid("2ac0910b-5462-426a-8ecb-01639f8314af"), "Huawei Matebook D15 Intel Core i7 1165G7 16GB 512GB SSD Windows 11 Home 15.6' Taşınabilir Bilgisayar", 1300.13m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Piece", "ProductId" },
                values: new object[,]
                {
                    { new Guid("1e0ca3a5-cfe2-4bea-98a7-b67ff7cc8474"), new Guid("fe63088f-6578-4ffe-aa9e-bf47bcc5fc21"), 13, new Guid("b2ea5779-f229-4c45-b565-553dd05aa079") },
                    { new Guid("61064396-2770-41dd-9075-c83bfee5b8f5"), new Guid("f188baed-84d3-423e-86fe-a442a2f5988f"), 13, new Guid("0df308d6-1d62-49f8-b87d-45121a8fb087") },
                    { new Guid("a0a9ee05-5cef-45c7-99f1-48f1145e8c48"), new Guid("f188baed-84d3-423e-86fe-a442a2f5988f"), 13, new Guid("b2ea5779-f229-4c45-b565-553dd05aa079") },
                    { new Guid("fd690002-7283-45d3-91a3-4d4fee7960db"), new Guid("d09978fd-3031-40dd-b6fb-bcc0cc368572"), 13, new Guid("a4436498-5dd2-49f4-a83c-850c8e46eaab") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
