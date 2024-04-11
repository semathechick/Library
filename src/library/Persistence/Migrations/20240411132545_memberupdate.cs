using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class memberupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ad34d731-c95e-47ef-b9af-9913a84592e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42d4f241-cb61-40c2-9fd9-1d4ea6722bdf"));

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherName",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c77acf58-d939-4484-a657-141669ee9ccf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 17, 238, 12, 98, 10, 250, 150, 126, 137, 67, 181, 217, 221, 164, 110, 254, 187, 234, 108, 206, 127, 212, 181, 16, 10, 244, 168, 135, 229, 62, 0, 141, 39, 6, 48, 248, 156, 14, 183, 67, 58, 183, 90, 150, 66, 246, 40, 235, 182, 219, 92, 242, 19, 120, 180, 12, 80, 77, 55, 20, 37, 60, 62, 183 }, new byte[] { 148, 254, 34, 41, 60, 213, 140, 206, 159, 216, 202, 197, 197, 147, 19, 66, 116, 71, 75, 224, 247, 112, 164, 214, 242, 75, 130, 106, 242, 101, 160, 163, 233, 200, 231, 8, 99, 160, 211, 236, 122, 205, 11, 110, 118, 252, 229, 77, 139, 74, 99, 100, 130, 199, 159, 109, 191, 155, 237, 244, 120, 64, 183, 170, 187, 38, 214, 65, 161, 100, 158, 32, 90, 156, 56, 6, 103, 105, 111, 37, 39, 1, 196, 57, 241, 109, 42, 163, 246, 188, 117, 153, 204, 233, 221, 191, 112, 200, 21, 226, 209, 156, 105, 125, 253, 219, 104, 65, 41, 75, 95, 222, 134, 201, 161, 100, 254, 176, 191, 54, 247, 117, 123, 194, 137, 10, 63, 170 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4674ea2a-0d72-41f3-a552-ca9b0e9556af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c77acf58-d939-4484-a657-141669ee9ccf") });

            migrationBuilder.CreateIndex(
                name: "Member_UserID_UK",
                table: "Members",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Member_UserID_UK",
                table: "Members");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4674ea2a-0d72-41f3-a552-ca9b0e9556af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c77acf58-d939-4484-a657-141669ee9ccf"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherName",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("42d4f241-cb61-40c2-9fd9-1d4ea6722bdf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 24, 194, 36, 159, 199, 157, 37, 121, 53, 148, 44, 136, 63, 31, 174, 207, 31, 93, 56, 9, 159, 230, 85, 5, 250, 19, 47, 32, 109, 215, 51, 147, 180, 233, 41, 5, 63, 48, 179, 181, 41, 13, 251, 250, 59, 181, 104, 237, 18, 80, 1, 101, 2, 94, 179, 244, 194, 158, 194, 215, 115, 226, 206, 222 }, new byte[] { 18, 117, 85, 114, 125, 16, 137, 12, 25, 63, 54, 203, 215, 206, 55, 45, 97, 59, 235, 203, 227, 188, 175, 185, 80, 147, 211, 176, 96, 111, 174, 91, 107, 161, 190, 104, 195, 182, 0, 230, 212, 41, 90, 152, 186, 78, 231, 27, 133, 83, 94, 252, 24, 27, 70, 121, 105, 195, 120, 6, 254, 129, 45, 130, 235, 219, 110, 209, 202, 251, 33, 34, 171, 243, 136, 36, 131, 138, 13, 227, 222, 61, 1, 246, 51, 133, 114, 246, 61, 174, 75, 99, 186, 225, 208, 2, 10, 122, 10, 127, 212, 106, 84, 247, 38, 102, 64, 74, 120, 91, 57, 199, 226, 93, 58, 200, 222, 2, 177, 167, 22, 165, 88, 85, 129, 89, 50, 144 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ad34d731-c95e-47ef-b9af-9913a84592e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("42d4f241-cb61-40c2-9fd9-1d4ea6722bdf") });

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }
    }
}
