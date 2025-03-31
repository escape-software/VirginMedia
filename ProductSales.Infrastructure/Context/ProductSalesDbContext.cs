//-------------------------------------------------------------------------------------------------
// Name        : ProductSalesDbContext
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductSales.Domain.Entities;

namespace ProductSales.Infrastructure.Context;

public partial class ProductSalesDbContext : DbContext
{
    public ProductSalesDbContext()
    {
    }

    public ProductSalesDbContext(DbContextOptions<ProductSalesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSaleSummary> ProductSaleSummaries { get; set; }

    public virtual DbSet<Segment> Segments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ProductSalesConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryName).HasMaxLength(30);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.DiscountName).HasMaxLength(10);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductName).HasMaxLength(20);
        });

        modelBuilder.Entity<ProductSaleSummary>(entity =>
        {
            entity.HasKey(e => e.SaleId);

            entity.ToTable("ProductSaleSummary");

            entity.Property(e => e.ManufacturingPrice).HasColumnType("money");
            entity.Property(e => e.SalePrice).HasColumnType("money");
            entity.Property(e => e.UnitsSold).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.Country).WithMany(p => p.ProductSaleSummaries)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSaleSummary_Country");

            entity.HasOne(d => d.Discount).WithMany(p => p.ProductSaleSummaries)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSaleSummary_Discount");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSaleSummaries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSaleSummary_Product");

            entity.HasOne(d => d.Segment).WithMany(p => p.ProductSaleSummaries)
                .HasForeignKey(d => d.SegmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSaleSummary_Segment");
        });

        modelBuilder.Entity<Segment>(entity =>
        {
            entity.ToTable("Segment");

            entity.Property(e => e.SegmentName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
