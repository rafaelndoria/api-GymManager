using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTypePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Payment_TypePaymentId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "TypePayment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypePayment",
                table: "TypePayment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TypePayment_TypePaymentId",
                table: "Payments",
                column: "TypePaymentId",
                principalTable: "TypePayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TypePayment_TypePaymentId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypePayment",
                table: "TypePayment");

            migrationBuilder.RenameTable(
                name: "TypePayment",
                newName: "Payment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Payment_TypePaymentId",
                table: "Payments",
                column: "TypePaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
