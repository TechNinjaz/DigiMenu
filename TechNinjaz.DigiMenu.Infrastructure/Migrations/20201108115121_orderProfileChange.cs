using Microsoft.EntityFrameworkCore.Migrations;

namespace TechNinjaz.DigiMenu.Infrastructure.Migrations
{
    public partial class orderProfileChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Order_UserProfile_CustomerId",
                "Order");

            migrationBuilder.DropForeignKey(
                "FK_Order_UserProfile_WaiterId",
                "Order");

            migrationBuilder.DropIndex(
                "IX_Order_CustomerId",
                "Order");

            migrationBuilder.DropIndex(
                "IX_Order_WaiterId",
                "Order");

            migrationBuilder.CreateIndex(
                "IX_Order_CustomerId",
                "Order",
                "CustomerId");

            migrationBuilder.CreateIndex(
                "IX_Order_WaiterId",
                "Order",
                "WaiterId");

            migrationBuilder.AddForeignKey(
                "FK_Order_UserProfile_CustomerId",
                "Order",
                "CustomerId",
                "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Order_UserProfile_WaiterId",
                "Order",
                "WaiterId",
                "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Order_UserProfile_CustomerId",
                "Order");

            migrationBuilder.DropForeignKey(
                "FK_Order_UserProfile_WaiterId",
                "Order");

            migrationBuilder.DropIndex(
                "IX_Order_CustomerId",
                "Order");

            migrationBuilder.DropIndex(
                "IX_Order_WaiterId",
                "Order");

            migrationBuilder.CreateIndex(
                "IX_Order_CustomerId",
                "Order",
                "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Order_WaiterId",
                "Order",
                "WaiterId",
                unique: true,
                filter: "[WaiterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                "FK_Order_UserProfile_CustomerId",
                "Order",
                "CustomerId",
                "UserProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                "FK_Order_UserProfile_WaiterId",
                "Order",
                "WaiterId",
                "UserProfile",
                principalColumn: "Id");
        }
    }
}