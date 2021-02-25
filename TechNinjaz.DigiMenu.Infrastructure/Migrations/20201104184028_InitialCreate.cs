using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechNinjaz.DigiMenu.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "MenuCategory",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CategoryImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_MenuCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "OrderStatus",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_OrderStatus", x => x.Id); });

            migrationBuilder.CreateTable(
                "PaymentMethod",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PaymentMethod", x => x.Id); });

            migrationBuilder.CreateTable(
                "Shift",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStartTime = table.Column<TimeSpan>(nullable: false),
                    ShiftEndTime = table.Column<TimeSpan>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Shift", x => x.Id); });

            migrationBuilder.CreateTable(
                "SittingTable",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableArea = table.Column<string>(nullable: false),
                    TableNumber = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_SittingTable", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserProfile",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    IsStaffMember = table.Column<bool>(nullable: false),
                    AuthUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        "FK_UserProfile_AspNetUsers_AuthUserId",
                        x => x.AuthUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "MenuItem",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ItemImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MenuCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        "FK_MenuItem_MenuCategory_MenuCategoryId",
                        x => x.MenuCategoryId,
                        "MenuCategory",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Order",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAmount = table.Column<decimal>("decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>("decimal(18,2)", nullable: false),
                    GratuityAmount = table.Column<decimal>("decimal(18,2)", nullable: false),
                    OrderStatusId = table.Column<int>(nullable: false),
                    WaiterId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        "FK_Order_UserProfile_CustomerId",
                        x => x.CustomerId,
                        "UserProfile",
                        "Id");
                    table.ForeignKey(
                        "FK_Order_OrderStatus_OrderStatusId",
                        x => x.OrderStatusId,
                        "OrderStatus",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Order_PaymentMethod_PaymentMethodId",
                        x => x.PaymentMethodId,
                        "PaymentMethod",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Order_UserProfile_WaiterId",
                        x => x.WaiterId,
                        "UserProfile",
                        "Id");
                });

            migrationBuilder.CreateTable(
                "MenuItemOption",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemOption", x => x.Id);
                    table.ForeignKey(
                        "FK_MenuItemOption_MenuItem_MenuItemId",
                        x => x.MenuItemId,
                        "MenuItem",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "OrderDetail",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        "FK_OrderDetail_MenuItem_MenuItemId",
                        x => x.MenuItemId,
                        "MenuItem",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_OrderDetail_Order_OrderId",
                        x => x.OrderId,
                        "Order",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "SelectedMenuOption",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    OrderDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedMenuOption", x => x.Id);
                    table.ForeignKey(
                        "FK_SelectedMenuOption_OrderDetail_OrderDetailId",
                        x => x.OrderDetailId,
                        "OrderDetail",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_MenuItem_MenuCategoryId",
                "MenuItem",
                "MenuCategoryId");

            migrationBuilder.CreateIndex(
                "IX_MenuItemOption_MenuItemId",
                "MenuItemOption",
                "MenuItemId");

            migrationBuilder.CreateIndex(
                "IX_Order_CustomerId",
                "Order",
                "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Order_OrderStatusId",
                "Order",
                "OrderStatusId");

            migrationBuilder.CreateIndex(
                "IX_Order_PaymentMethodId",
                "Order",
                "PaymentMethodId");

            migrationBuilder.CreateIndex(
                "IX_Order_WaiterId",
                "Order",
                "WaiterId",
                unique: true,
                filter: "[WaiterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_OrderDetail_MenuItemId",
                "OrderDetail",
                "MenuItemId");

            migrationBuilder.CreateIndex(
                "IX_OrderDetail_OrderId",
                "OrderDetail",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_SelectedMenuOption_OrderDetailId",
                "SelectedMenuOption",
                "OrderDetailId");

            migrationBuilder.CreateIndex(
                "IX_UserProfile_AuthUserId",
                "UserProfile",
                "AuthUserId",
                unique: true,
                filter: "[AuthUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "MenuItemOption");

            migrationBuilder.DropTable(
                "SelectedMenuOption");

            migrationBuilder.DropTable(
                "Shift");

            migrationBuilder.DropTable(
                "SittingTable");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "OrderDetail");

            migrationBuilder.DropTable(
                "MenuItem");

            migrationBuilder.DropTable(
                "Order");

            migrationBuilder.DropTable(
                "MenuCategory");

            migrationBuilder.DropTable(
                "UserProfile");

            migrationBuilder.DropTable(
                "OrderStatus");

            migrationBuilder.DropTable(
                "PaymentMethod");

            migrationBuilder.DropTable(
                "AspNetUsers");
        }
    }
}