using Microsoft.EntityFrameworkCore.Migrations;

namespace OsfPay.Migrations
{
    public partial class DbSetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "PayedAmount",
                table: "Payments",
                newName: "PaidAmount");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "Payments",
                newName: "PayedAmount");

            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    PaymentDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    TotalPayment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.PaymentDetailID);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_OrderId",
                table: "PaymentDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_PaymentId",
                table: "PaymentDetail",
                column: "PaymentId");
        }
    }
}
