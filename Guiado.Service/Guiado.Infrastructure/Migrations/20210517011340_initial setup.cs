using Microsoft.EntityFrameworkCore.Migrations;

namespace Guiado.Infrastructure.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<int>(type: "int", nullable: false),
                    CoverArea = table.Column<int>(type: "int", nullable: false),
                    StartBusinessHour = table.Column<int>(type: "int", nullable: false),
                    EndBusinessHour = table.Column<int>(type: "int", nullable: false),
                    AvailableDays = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Users_Owner",
                        column: x => x.Owner,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProductFamily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    ProductFamilyID = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProductFamily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProductFamily_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProductFamily_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProductFamily_ProductFamilies_ProductFamilyID",
                        column: x => x.ProductFamilyID,
                        principalTable: "ProductFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductFamilyID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductFamilies_ProductFamilyID",
                        column: x => x.ProductFamilyID,
                        principalTable: "ProductFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_Owner",
                table: "Businesses",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProductFamily_BusinessId",
                table: "BusinessProductFamily",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProductFamily_BusinessID",
                table: "BusinessProductFamily",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProductFamily_ProductFamilyID",
                table: "BusinessProductFamily",
                column: "ProductFamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BusinessId",
                table: "Products",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BusinessID",
                table: "Products",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFamilyID",
                table: "Products",
                column: "ProductFamilyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProductFamily");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "ProductFamilies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
