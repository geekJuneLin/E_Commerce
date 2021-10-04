using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class AddedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54f5f4c1-2cf5-4489-b612-9af96fa950a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fe0ed39-8157-42da-9465-4ba7dd55d2ec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61a1daf1-5d63-4d78-a404-e56b3c39cf7a");

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("59d0145f-43e8-453f-a34e-e08975dc5801"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("64261916-33d3-40d7-ace7-f0b19e26995c"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("c295ffea-d71c-43c5-bcc0-701b69b4c4be"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ProductItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d361326-39e0-4d91-915b-7be3302d0b09", "26152936-c8ec-48cd-8345-e7d930e12e24", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3725e6a5-8426-4dc1-92f0-842741b6141b", 0, "6089872f-b2a7-43ef-8925-f2745bf8ab58", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAENp8rgA96H8gsF/0jh3p1LIdBjo1OnQXTjxEk95ywpPiLeAYGq3K8HwHhDIPtE7OBA==", null, false, "8c921253-b104-426c-835b-161db776bf73", false, "test@test.com" },
                    { "63948654-8e56-48f9-a51a-ba60beb12e44", 0, "cddd7222-e07b-49f3-a5b4-00d3efb24795", "admin@appstore.com", true, false, null, "ADMIN@APPSTORE.COM", "ADMIN@APPSTORE.COM", "AQAAAAEAACcQAAAAECBfN5675NCTPoMu7P2wD353/Y19tuwgn0Fwni30WGDkwE85VpvoZXJcM9HdEibXXQ==", null, false, "5db25119-03f3-448c-95c7-bffc54a098af", false, "admin@appstore.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "CategoryId", "Description", "OrderId", "Price", "ProductName", "QtyAvailable" },
                values: new object[,]
                {
                    { new Guid("240777bb-486e-4e03-a05b-77a43cc90edc"), null, "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1399m, "iPhone 12 Pro", 1 },
                    { new Guid("2b1fe942-8501-475a-8014-034d504dd4ce"), null, "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1599m, "iPhone 12 Pro Max", 10 },
                    { new Guid("b1f8488b-063d-41bd-b735-18d963dbc0fd"), null, "iPad Pro is a premium edition of the iPad tablet computers developed by Apple. It initially ran iOS,[12] but was later switched to a derivation of the same equivalent that is optimized for the iPad, iPadOS.[13] The first iPad Pro was introduced on September 9, 2015, running iOS 9.", null, 1399m, "iPad Pro", 99 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "63948654-8e56-48f9-a51a-ba60beb12e44", "6d361326-39e0-4d91-915b-7be3302d0b09" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_CategoryId",
                table: "ProductItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Category_CategoryId",
                table: "ProductItems",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Category_CategoryId",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_CategoryId",
                table: "ProductItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "63948654-8e56-48f9-a51a-ba60beb12e44", "6d361326-39e0-4d91-915b-7be3302d0b09" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3725e6a5-8426-4dc1-92f0-842741b6141b");

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("240777bb-486e-4e03-a05b-77a43cc90edc"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("2b1fe942-8501-475a-8014-034d504dd4ce"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("b1f8488b-063d-41bd-b735-18d963dbc0fd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d361326-39e0-4d91-915b-7be3302d0b09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63948654-8e56-48f9-a51a-ba60beb12e44");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54f5f4c1-2cf5-4489-b612-9af96fa950a1", "2cc6159c-8a53-45de-bad2-cd32db0bdced", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4fe0ed39-8157-42da-9465-4ba7dd55d2ec", 0, "fc3bbe12-7c87-47bf-aa11-1059e97d4f2a", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEEjq+GRx7RsOiPWRex1PQYqmN0jkUoKLF5iGSoz0XlWPuCnVuB4fWVRdgfsIIhZF5g==", null, false, "3e6fcc4b-2eb0-443f-ada9-6e653331a753", false, "test@test.com" },
                    { "61a1daf1-5d63-4d78-a404-e56b3c39cf7a", 0, "2a51940b-78d5-4b39-bf20-c7e261833585", "admin@appstore.com", true, false, null, "ADMIN@APPSTORE.COM", "ADMIN@APPSTORE.COM", "AQAAAAEAACcQAAAAECLzVGE3gBiCuWvxpX6U88dMEWYQGJN+d7lSxw0z+iiUlO1A6g/bEShkUdoXO4Z3dA==", null, false, "bbf89d12-b70e-4959-a2a9-1c20f423a666", false, "admin@appstore.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "Description", "OrderId", "Price", "ProductName", "QtyAvailable" },
                values: new object[,]
                {
                    { new Guid("59d0145f-43e8-453f-a34e-e08975dc5801"), "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1399m, "iPhone 12 Pro", 1 },
                    { new Guid("c295ffea-d71c-43c5-bcc0-701b69b4c4be"), "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1599m, "iPhone 12 Pro Max", 10 },
                    { new Guid("64261916-33d3-40d7-ace7-f0b19e26995c"), "iPad Pro is a premium edition of the iPad tablet computers developed by Apple. It initially ran iOS,[12] but was later switched to a derivation of the same equivalent that is optimized for the iPad, iPadOS.[13] The first iPad Pro was introduced on September 9, 2015, running iOS 9.", null, 1399m, "iPad Pro", 99 }
                });
        }
    }
}
