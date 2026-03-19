using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftPay.Migrations
{
    /// <inheritdoc />
    public partial class Final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RateLock",
                table: "RateLock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FXQuote",
                table: "FXQuote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeRule",
                table: "FeeRule");

            migrationBuilder.RenameTable(
                name: "RateLock",
                newName: "RateLocks");

            migrationBuilder.RenameTable(
                name: "FXQuote",
                newName: "FXQuotes");

            migrationBuilder.RenameTable(
                name: "FeeRule",
                newName: "FeeRules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateLocks",
                table: "RateLocks",
                column: "LockID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FXQuotes",
                table: "FXQuotes",
                column: "QuoteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeRules",
                table: "FeeRules",
                column: "FeeRuleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RateLocks",
                table: "RateLocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FXQuotes",
                table: "FXQuotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeRules",
                table: "FeeRules");

            migrationBuilder.RenameTable(
                name: "RateLocks",
                newName: "RateLock");

            migrationBuilder.RenameTable(
                name: "FXQuotes",
                newName: "FXQuote");

            migrationBuilder.RenameTable(
                name: "FeeRules",
                newName: "FeeRule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateLock",
                table: "RateLock",
                column: "LockID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FXQuote",
                table: "FXQuote",
                column: "QuoteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeRule",
                table: "FeeRule",
                column: "FeeRuleID");
        }
    }
}
