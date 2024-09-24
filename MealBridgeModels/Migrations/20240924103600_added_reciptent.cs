using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealBridgeModels.Migrations
{
    /// <inheritdoc />
    public partial class added_reciptent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_DonorId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Donations",
                newName: "FkDonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                newName: "IX_Donations_FkDonorId");

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkDonationId = table.Column<int>(type: "int", nullable: true),
                    FkUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.RecipientId);
                    table.ForeignKey(
                        name: "FK_Recipient_Donations_FkDonationId",
                        column: x => x.FkDonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId");
                    table.ForeignKey(
                        name: "FK_Recipient_Users_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_FkDonationId",
                table: "Recipient",
                column: "FkDonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_FkUserId",
                table: "Recipient",
                column: "FkUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_FkDonorId",
                table: "Donations",
                column: "FkDonorId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_FkDonorId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.RenameColumn(
                name: "FkDonorId",
                table: "Donations",
                newName: "DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_FkDonorId",
                table: "Donations",
                newName: "IX_Donations_DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
