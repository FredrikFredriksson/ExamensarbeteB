using Microsoft.EntityFrameworkCore.Migrations;

namespace AngensGard.Migrations
{
    public partial class newtablescreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Delivery_DeliveryId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_DeliveryId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "OrderDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Interval = table.Column<string>(type: "TEXT", nullable: true),
                    IsHomeDelivery = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeliveryId",
                table: "OrderDetails",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Delivery_DeliveryId",
                table: "OrderDetails",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
