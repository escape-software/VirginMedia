﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductSales.Infrastructure.Context;

#nullable disable

namespace ProductSales.Infrastructure.Migrations
{
    [DbContext(typeof(ProductSalesDbContext))]
    [Migration("20240719115455_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductSales.Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CountryId");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<string>("DiscountName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ProductId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.ProductSaleSummary", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ManufacturingPrice")
                        .HasColumnType("money");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal?>("SalePrice")
                        .HasColumnType("money");

                    b.Property<int>("SegmentId")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitsSold")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("SaleId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SegmentId");

                    b.ToTable("ProductSaleSummary", (string)null);
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Segment", b =>
                {
                    b.Property<int>("SegmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SegmentId"));

                    b.Property<string>("SegmentName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SegmentId");

                    b.ToTable("Segment", (string)null);
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.ProductSaleSummary", b =>
                {
                    b.HasOne("ProductSales.Domain.Entities.Country", "Country")
                        .WithMany("ProductSaleSummaries")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductSaleSummary_Country");

                    b.HasOne("ProductSales.Domain.Entities.Discount", "Discount")
                        .WithMany("ProductSaleSummaries")
                        .HasForeignKey("DiscountId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductSaleSummary_Discount");

                    b.HasOne("ProductSales.Domain.Entities.Product", "Product")
                        .WithMany("ProductSaleSummaries")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductSaleSummary_Product");

                    b.HasOne("ProductSales.Domain.Entities.Segment", "Segment")
                        .WithMany("ProductSaleSummaries")
                        .HasForeignKey("SegmentId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductSaleSummary_Segment");

                    b.Navigation("Country");

                    b.Navigation("Discount");

                    b.Navigation("Product");

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Country", b =>
                {
                    b.Navigation("ProductSaleSummaries");
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Discount", b =>
                {
                    b.Navigation("ProductSaleSummaries");
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductSaleSummaries");
                });

            modelBuilder.Entity("ProductSales.Domain.Entities.Segment", b =>
                {
                    b.Navigation("ProductSaleSummaries");
                });
#pragma warning restore 612, 618
        }
    }
}
