using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApplication.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountPosting",
                columns: table => new
                {
                    BankAccountPostingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transactiontype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountPosting", x => x.BankAccountPostingId);
                    table.ForeignKey(
                        name: "FK_BankAccountPosting_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountPosting_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    BankTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.BankTransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransaction_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransaction_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountTypeId",
                table: "BankAccount",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPosting_BankAccountId",
                table: "BankAccountPosting",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPosting_PaymentMethodId",
                table: "BankAccountPosting",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_BankAccountId",
                table: "BankTransaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_PaymentMethodId",
                table: "BankTransaction",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountPosting");

            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
