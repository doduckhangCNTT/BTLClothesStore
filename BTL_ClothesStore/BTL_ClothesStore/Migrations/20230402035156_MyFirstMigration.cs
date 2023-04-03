using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTL_ClothesStore.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    inStock = table.Column<int>(type: "int", nullable: false),
                    outOfStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopping_cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    avaliablity_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK__Product__avaliab__3F466844",
                        column: x => x.avaliablity_id,
                        principalTable: "Availability",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Product__categor__3E52440B",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<int>(type: "int", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_details", x => x.id);
                    table.ForeignKey(
                        name: "FK__Order_det__order__4222D4EF",
                        column: x => x.order_status_id,
                        principalTable: "Order_Status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quanlity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<int>(type: "int", nullable: false),
                    shopping_cart_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK__Cart_Item__produ__44FF419A",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Cart_Item__shopp__45F365D3",
                        column: x => x.shopping_cart_id,
                        principalTable: "shopping_cart",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quanlity = table.Column<int>(type: "int", nullable: false),
                    order_detail_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK__Order_Ite__order__49C3F6B7",
                        column: x => x.order_detail_id,
                        principalTable: "Order_details",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Order_Ite__produ__48CFD27E",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_product_id",
                table: "Cart_Item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Item_shopping_cart_id",
                table: "Cart_Item",
                column: "shopping_cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_order_status_id",
                table: "Order_details",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_order_detail_id",
                table: "Order_Items",
                column: "order_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_product_id",
                table: "Order_Items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_avaliablity_id",
                table: "Product",
                column: "avaliablity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Item");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "shopping_cart");

            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
