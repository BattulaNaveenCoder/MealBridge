using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealBridgeModels.Migrations
{
    /// <inheritdoc />
    public partial class feed_model_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Donations_FkDonationId",
                table: "Recipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Users_FkUserId",
                table: "Recipient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipient",
                table: "Recipient");

            migrationBuilder.RenameTable(
                name: "Recipient",
                newName: "Recipients");

            migrationBuilder.RenameIndex(
                name: "IX_Recipient_FkUserId",
                table: "Recipients",
                newName: "IX_Recipients_FkUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipient_FkDonationId",
                table: "Recipients",
                newName: "IX_Recipients_FkDonationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients",
                column: "RecipientId");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkDonorId = table.Column<int>(type: "int", nullable: true),
                    FkRecipientId = table.Column<int>(type: "int", nullable: true),
                    FkDonationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Donations_FkRecipientId",
                        column: x => x.FkRecipientId,
                        principalTable: "Donations",
                        principalColumn: "DonationId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_FkDonorId",
                        column: x => x.FkDonorId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_FkRecipientId",
                        column: x => x.FkRecipientId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FkDonationId = table.Column<int>(type: "int", nullable: true),
                    FkRecipientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_Tokens_Donations_FkDonationId",
                        column: x => x.FkDonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId");
                    table.ForeignKey(
                        name: "FK_Tokens_Recipients_FkRecipientId",
                        column: x => x.FkRecipientId,
                        principalTable: "Recipients",
                        principalColumn: "RecipientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FkDonorId",
                table: "Feedbacks",
                column: "FkDonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FkRecipientId",
                table: "Feedbacks",
                column: "FkRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_FkDonationId",
                table: "Tokens",
                column: "FkDonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_FkRecipientId",
                table: "Tokens",
                column: "FkRecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Donations_FkDonationId",
                table: "Recipients",
                column: "FkDonationId",
                principalTable: "Donations",
                principalColumn: "DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Users_FkUserId",
                table: "Recipients",
                column: "FkUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Donations_FkDonationId",
                table: "Recipients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Users_FkUserId",
                table: "Recipients");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipients",
                table: "Recipients");

            migrationBuilder.RenameTable(
                name: "Recipients",
                newName: "Recipient");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_FkUserId",
                table: "Recipient",
                newName: "IX_Recipient_FkUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipients_FkDonationId",
                table: "Recipient",
                newName: "IX_Recipient_FkDonationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipient",
                table: "Recipient",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Donations_FkDonationId",
                table: "Recipient",
                column: "FkDonationId",
                principalTable: "Donations",
                principalColumn: "DonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Users_FkUserId",
                table: "Recipient",
                column: "FkUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
