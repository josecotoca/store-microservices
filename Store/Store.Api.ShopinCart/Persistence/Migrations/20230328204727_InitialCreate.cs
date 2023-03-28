using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Store.Api.ShopinCart.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoice_name = table.Column<string>(type: "text", nullable: false),
                    invoice_nit = table.Column<string>(type: "text", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delivered = table.Column<string>(type: "text", nullable: false),
                    date_delivered = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    subtotal = table.Column<double>(type: "double precision", nullable: false),
                    charge_tax = table.Column<double>(type: "double precision", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sales_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sale_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    subtotal = table.Column<double>(type: "double precision", nullable: false),
                    charge_tax = table.Column<double>(type: "double precision", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_sales_details_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sales_details_sale_id",
                table: "sales_details",
                column: "sale_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales_details");

            migrationBuilder.DropTable(
                name: "sales");
        }
    }
}
