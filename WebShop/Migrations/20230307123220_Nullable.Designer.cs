﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Context;

#nullable disable

namespace WebShop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230307123220_Nullable")]
    partial class Nullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductEntityTagEntity", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("ProductEntityTagEntity");
                });

            modelBuilder.Entity("WebShop.Models.Entities.DescriptionEntity", b =>
                {
                    b.Property<int>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DescriptionId"));

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DescriptionId");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("WebShop.Models.Entities.ImageEntity", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WebShop.Models.Entities.ProductEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("DescriptionId")
                        .IsUnique()
                        .HasFilter("[DescriptionId] IS NOT NULL");

                    b.HasIndex("ReviewId")
                        .IsUnique()
                        .HasFilter("[ReviewId] IS NOT NULL");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebShop.Models.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebShop.Models.Entities.TagEntity", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProductEntityTagEntity", b =>
                {
                    b.HasOne("WebShop.Models.Entities.ProductEntity", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebShop.Models.Entities.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebShop.Models.Entities.ImageEntity", b =>
                {
                    b.HasOne("WebShop.Models.Entities.ProductEntity", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebShop.Models.Entities.ProductEntity", b =>
                {
                    b.HasOne("WebShop.Models.Entities.DescriptionEntity", "Description")
                        .WithOne("Product")
                        .HasForeignKey("WebShop.Models.Entities.ProductEntity", "DescriptionId");

                    b.HasOne("WebShop.Models.Entities.ReviewEntity", "Review")
                        .WithOne("Product")
                        .HasForeignKey("WebShop.Models.Entities.ProductEntity", "ReviewId");

                    b.Navigation("Description");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("WebShop.Models.Entities.DescriptionEntity", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("WebShop.Models.Entities.ProductEntity", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("WebShop.Models.Entities.ReviewEntity", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
