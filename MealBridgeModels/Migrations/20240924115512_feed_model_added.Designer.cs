﻿// <auto-generated />
using System;
using MealBridgeModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MealBridgeModels.Migrations
{
    [DbContext(typeof(FoodDonationContext))]
    [Migration("20240924115512_feed_model_added")]
    partial class feed_model_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealBridgeModels.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonationId"));

                    b.Property<DateTime>("AvailableUntil")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonationType")
                        .HasColumnType("int");

                    b.Property<int?>("FkDonorId")
                        .HasColumnType("int");

                    b.Property<string>("FoodType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MealCount")
                        .HasColumnType("int");

                    b.Property<string>("PickupLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("PickupTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("DonationId");

                    b.HasIndex("FkDonorId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkDonationId")
                        .HasColumnType("int");

                    b.Property<int?>("FkDonorId")
                        .HasColumnType("int");

                    b.Property<int?>("FkRecipientId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("FkDonorId");

                    b.HasIndex("FkRecipientId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Recipient", b =>
                {
                    b.Property<int>("RecipientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipientId"));

                    b.Property<int?>("FkDonationId")
                        .HasColumnType("int");

                    b.Property<int?>("FkUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RecipientId");

                    b.HasIndex("FkDonationId");

                    b.HasIndex("FkUserId");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Token", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenId"));

                    b.Property<DateTime?>("ClaimedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkDonationId")
                        .HasColumnType("int");

                    b.Property<int?>("FkRecipientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TokenCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TokenId");

                    b.HasIndex("FkDonationId");

                    b.HasIndex("FkRecipientId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("MealBridgeModels.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Donation", b =>
                {
                    b.HasOne("MealBridgeModels.Models.User", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("FkDonorId");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Feedback", b =>
                {
                    b.HasOne("MealBridgeModels.Models.User", "Donor")
                        .WithMany()
                        .HasForeignKey("FkDonorId");

                    b.HasOne("MealBridgeModels.Models.Donation", "Donation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("FkRecipientId");

                    b.HasOne("MealBridgeModels.Models.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("FkRecipientId");

                    b.Navigation("Donation");

                    b.Navigation("Donor");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Recipient", b =>
                {
                    b.HasOne("MealBridgeModels.Models.Donation", "Donation")
                        .WithMany("Recipients")
                        .HasForeignKey("FkDonationId");

                    b.HasOne("MealBridgeModels.Models.User", "User")
                        .WithMany("Recipients")
                        .HasForeignKey("FkUserId");

                    b.Navigation("Donation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Token", b =>
                {
                    b.HasOne("MealBridgeModels.Models.Donation", "Donation")
                        .WithMany("Tokens")
                        .HasForeignKey("FkDonationId");

                    b.HasOne("MealBridgeModels.Models.Recipient", "Recipient")
                        .WithMany("Tokens")
                        .HasForeignKey("FkRecipientId");

                    b.Navigation("Donation");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Donation", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Recipients");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("MealBridgeModels.Models.Recipient", b =>
                {
                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("MealBridgeModels.Models.User", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}