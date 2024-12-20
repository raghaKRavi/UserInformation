using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserInfo.Migrations
{
    /// <inheritdoc />
    public partial class updation_on_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "user_info");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user_info",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "user_info",
                newName: "dob");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "user_info",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_info",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "user_info",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "user_info",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "user_info",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "user_info",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "user_info",
                newName: "created_at");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_info",
                table: "user_info",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_info",
                table: "user_info");

            migrationBuilder.RenameTable(
                name: "user_info",
                newName: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "UserInfo",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dob",
                table: "UserInfo",
                newName: "Dob");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "UserInfo",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "UserInfo",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "UserInfo",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "UserInfo",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "UserInfo",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "UserInfo",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");
        }
    }
}
