using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class AddedSaleSalePerBadgeForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Category_CategoryId",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

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
                name: "Id",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ProductItems",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Badge",
                table: "ProductItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "ProductItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SalePercetage",
                table: "ProductItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "730b9644-3480-4433-9e2b-8c43e0487b0a", "94757982-a277-4e2a-9973-43c8b38782b8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "875f47e5-2ce1-4298-b6f7-2d3fd41d0be9", 0, "24c3db86-11ad-4029-a88c-98be81f1e30f", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEHPhC60voipnRXJ7g8pwAWFA0EFvkv0tUFHdYoFqayrQ2cqFn9QsATZ+cTHqPcM93A==", null, false, "64cde885-55fe-4e9e-bfa3-2266925dc95f", false, "test@test.com" },
                    { "e4cf7390-b811-4eab-9e23-e8a777727a5a", 0, "ae7a4d7a-cfd3-4bc0-8c45-a937afa9df4f", "admin@appstore.com", true, false, null, "ADMIN@APPSTORE.COM", "ADMIN@APPSTORE.COM", "AQAAAAEAACcQAAAAEOe3s4sZ+YxMX6RzUzDyFVibsRUJcY+Rve1CMn6Ubg+B10lvZRAZ0QKBrmJp3mOLjA==", null, false, "ff2e4e6b-126c-4808-97c1-a4ca1b5aea36", false, "admin@appstore.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { new Guid("9751504c-23fe-4461-aeac-26aa85b4c1db"), "Electrical" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e4cf7390-b811-4eab-9e23-e8a777727a5a", "730b9644-3480-4433-9e2b-8c43e0487b0a" });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "Badge", "CategoryId", "Description", "OrderId", "Price", "ProductName", "QtyAvailable", "Ratings", "SalePercetage" },
                values: new object[,]
                {
                    { new Guid("2db0cfb8-885b-47d6-885b-05959007af9b"), "New", new Guid("9751504c-23fe-4461-aeac-26aa85b4c1db"), "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1399m, "iPhone 12 Pro", 1, 5, 0.0 },
                    { new Guid("fd644965-10c4-447d-939d-1605f31c02fc"), "New", new Guid("9751504c-23fe-4461-aeac-26aa85b4c1db"), "The iPhone 12 Pro and iPhone 12 Pro Max are smartphones designed and marketed by Apple Inc. They are the flagship smartphones in the fourteenth generation of the iPhone, succeeding the iPhone 11 Pro and iPhone 11 Pro Max. They were announced on October 13, 2020, with the iPhone 12 Pro being released on October 23, 2020, and the iPhone 12 Pro Max on November 13, 2020", null, 1599m, "iPhone 12 Pro Max", 10, 5, 0.0 },
                    { new Guid("4a7ef0e1-049c-41d7-badf-af058e16c075"), "Sale", new Guid("9751504c-23fe-4461-aeac-26aa85b4c1db"), "iPad Pro is a premium edition of the iPad tablet computers developed by Apple. It initially ran iOS,[12] but was later switched to a derivation of the same equivalent that is optimized for the iPad, iPadOS.[13] The first iPad Pro was introduced on September 9, 2015, running iOS 9.", null, 1399m, "iPad Pro", 99, 4, 0.75 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Categories_CategoryId",
                table: "ProductItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Categories_CategoryId",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e4cf7390-b811-4eab-9e23-e8a777727a5a", "730b9644-3480-4433-9e2b-8c43e0487b0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "875f47e5-2ce1-4298-b6f7-2d3fd41d0be9");

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("2db0cfb8-885b-47d6-885b-05959007af9b"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("4a7ef0e1-049c-41d7-badf-af058e16c075"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("fd644965-10c4-447d-939d-1605f31c02fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "730b9644-3480-4433-9e2b-8c43e0487b0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4cf7390-b811-4eab-9e23-e8a777727a5a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9751504c-23fe-4461-aeac-26aa85b4c1db"));

            migrationBuilder.DropColumn(
                name: "Badge",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "SalePercetage",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ProductItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Category_CategoryId",
                table: "ProductItems",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
