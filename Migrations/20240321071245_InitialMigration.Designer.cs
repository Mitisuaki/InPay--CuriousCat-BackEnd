﻿// <auto-generated />
using System;
using InPay__CuriousCat_BackEnd.Domain.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InPay__CuriousCat_BackEnd.Migrations
{
    [DbContext(typeof(InpayDbContext))]
    [Migration("20240321071245_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.AccTransaction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("AccID")
                        .HasColumnType("integer");

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("Date")
                        .HasColumnType("integer");

                    b.Property<int>("Direction")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("AccId")
                        .HasColumnType("integer");

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsACompanyAdress")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCurrentAdress")
                        .HasColumnType("boolean");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Card", b =>
                {
                    b.Property<int>("CardNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CardNumber"));

                    b.Property<int>("AccId")
                        .HasColumnType("integer");

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expirationdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Flag")
                        .HasColumnType("integer");

                    b.Property<string>("HashCardPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCreditEnabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProximityEnabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVirtual")
                        .HasColumnType("boolean");

                    b.Property<int>("VinculatedCardNumber")
                        .HasColumnType("integer");

                    b.HasKey("CardNumber");

                    b.HasIndex("AccId");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<double>("AccLimit")
                        .HasColumnType("double precision");

                    b.Property<string>("AccNickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AccNumber")
                        .HasColumnType("integer");

                    b.Property<string>("AccRecoveryCode")
                        .HasColumnType("text");

                    b.Property<int>("AccType")
                        .HasColumnType("integer");

                    b.Property<int>("Agency")
                        .HasColumnType("integer");

                    b.Property<double>("AvailableLimit")
                        .HasColumnType("double precision");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("CompanyEmail")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<double>("ConfiguredAccLimit")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HashPasswordPJ")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("TransactionLimit")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Phones")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecoveryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.AccTransaction", b =>
                {
                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Adress", b =>
                {
                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", "Account")
                        .WithMany("AdressesHistory")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Card", b =>
                {
                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.Card", "VinculatedCard")
                        .WithMany()
                        .HasForeignKey("AccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("VinculatedCard");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", b =>
                {
                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Phone", b =>
                {
                    b.HasOne("InPay__CuriousCat_BackEnd.Domain.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.Interfaces.Account", b =>
                {
                    b.Navigation("AdressesHistory");

                    b.Navigation("Cards");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("InPay__CuriousCat_BackEnd.Domain.Models.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
