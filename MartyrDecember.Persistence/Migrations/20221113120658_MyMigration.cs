using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MartyrDecember.Persistence.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageUrl",
                table: "ProfilePictures",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "f3d357c7-8b72-4ea4-9a42-41c1d38e5e97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "2468894f-ff01-41e5-b75a-cdf178e81aec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fb3e23e-4751-4da1-bc59-346b3ab39588", "AQAAAAEAACcQAAAAEBpcFZ14uOP9QRWCLrqt1PsvmzXFTRbZJ24x3bgRQq4iQdnlYMfWf5tR2ndi1YobHQ==", "33cacbfc-3e31-48c6-92ed-2884e202cefe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cc717e5-4137-4b96-bc8e-096955d01691", "AQAAAAEAACcQAAAAEFPHzu/sShSMjghPyLcg0CBx8IynO+KSOlCcoabCmICUvPoc8ufFJJ3RIu7zayv2rw==", "7343712c-c40c-4677-9928-6d736e6dd6fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageUrl",
                table: "ProfilePictures",
                type: "varbinary(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6c5ef9bc-f37b-44a9-b93e-e2e6b1b89205");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "45788f0f-f570-4c70-8322-51cb0f424608");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38f49333-3648-44ed-8028-d888ae225180", "AQAAAAEAACcQAAAAENmSJtFFtgriQLi5GE8cjNYGr4i3joZxxSYly9pdUFnbl3N55UILImtp7nNZW+Wksw==", "6374bdac-05a4-4f38-9d69-840d37599dbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4b535f1-414d-4633-a089-02e8114a0bba", "AQAAAAEAACcQAAAAEIT7lWGqGtyqWYrtkGg5Ym/B/hXm1FA/u3OLtbEvBC3sJbBRZ7H4GjGvPYQmZKNKAg==", "2bdd2373-d99a-4316-867f-0e2636033d3a" });
        }
    }
}
