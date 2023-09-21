﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230921133700_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Data.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_registration");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("initials");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("WebAPI.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Article")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("article");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Article")
                        .HasName("pk_product");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("WebAPI.Data.Models.ProductPurchase", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uuid")
                        .HasColumnName("purchase_id");

                    b.HasKey("ProductId", "PurchaseId")
                        .HasName("pk_product_purchase");

                    b.HasIndex("PurchaseId")
                        .HasDatabaseName("ix_product_purchase_purchase_id");

                    b.ToTable("product_purchase", (string)null);
                });

            modelBuilder.Entity("WebAPI.Data.Models.Purchase", b =>
                {
                    b.Property<Guid>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("number");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("numeric")
                        .HasColumnName("total_value");

                    b.HasKey("Number")
                        .HasName("pk_purchase");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_purchase_client_id");

                    b.ToTable("purchase", (string)null);
                });

            modelBuilder.Entity("WebAPI.Data.Models.ProductPurchase", b =>
                {
                    b.HasOne("WebAPI.Data.Models.Product", "Product")
                        .WithMany("ProductPurchases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_purchase_product_product_temp_id");

                    b.HasOne("WebAPI.Data.Models.Purchase", "Purchase")
                        .WithMany("Products")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_purchase_purchase_purchase_temp_id");

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("WebAPI.Data.Models.Purchase", b =>
                {
                    b.HasOne("WebAPI.Data.Models.Client", "Client")
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_purchase_clients_client_id");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebAPI.Data.Models.Client", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("WebAPI.Data.Models.Product", b =>
                {
                    b.Navigation("ProductPurchases");
                });

            modelBuilder.Entity("WebAPI.Data.Models.Purchase", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}