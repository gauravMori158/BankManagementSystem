﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class V14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BankAccount_AccountTypeId",
                table: "BankAccount");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountTypeId",
                table: "BankAccount",
                column: "AccountTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BankAccount_AccountTypeId",
                table: "BankAccount");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountTypeId",
                table: "BankAccount",
                column: "AccountTypeId",
                unique: true);
        }
    }
}
