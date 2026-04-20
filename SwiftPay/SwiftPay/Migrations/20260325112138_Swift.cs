using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPay.Migrations
{
    /// <inheritdoc />
    public partial class Swift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_User_UserID",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_User_UserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_KYCRecords_User_UserID",
                table: "KYCRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationAlerts_User_UserID",
                table: "NotificationAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_AccountOrWalletNo",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_CustomerID",
                table: "Beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Phone",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "[User]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_[User]",
                table: "[User]",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_RoleId",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_CustomerID_AccountOrWalletNo",
                table: "Beneficiaries",
                columns: new[] { "CustomerID", "AccountOrWalletNo" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_[User]_Email",
                table: "[User]",
                column: "Email",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_[User]_Phone",
                table: "[User]",
                column: "Phone",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_[User]_UserID",
                table: "AuditLogs",
                column: "UserID",
                principalTable: "[User]",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_[User]_UserID",
                table: "Customers",
                column: "UserID",
                principalTable: "[User]",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KYCRecords_[User]_UserID",
                table: "KYCRecords",
                column: "UserID",
                principalTable: "[User]",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationAlerts_[User]_UserID",
                table: "NotificationAlerts",
                column: "UserID",
                principalTable: "[User]",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_[User]_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "[User]",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_[User]_UserID",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_[User]_UserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_KYCRecords_[User]_UserID",
                table: "KYCRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationAlerts_[User]_UserID",
                table: "NotificationAlerts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_[User]_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId_RoleId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_CustomerID_AccountOrWalletNo",
                table: "Beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_[User]",
                table: "[User]");

            migrationBuilder.DropIndex(
                name: "IX_[User]_Email",
                table: "[User]");

            migrationBuilder.DropIndex(
                name: "IX_[User]_Phone",
                table: "[User]");

            migrationBuilder.RenameTable(
                name: "[User]",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AccountOrWalletNo",
                table: "Beneficiaries",
                column: "AccountOrWalletNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_CustomerID",
                table: "Beneficiaries",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_User_UserID",
                table: "AuditLogs",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_User_UserID",
                table: "Customers",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KYCRecords_User_UserID",
                table: "KYCRecords",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationAlerts_User_UserID",
                table: "NotificationAlerts",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
