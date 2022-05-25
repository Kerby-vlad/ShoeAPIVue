﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.DataBase;

#nullable disable

namespace Shop.DataBase.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Data.Models.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Shop.Data.Models.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Shop.Data.Models.BrandType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("TypeId");

                    b.ToTable("BrandTypes");
                });

            modelBuilder.Entity("Shop.Data.Models.Good", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("TypeId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Shop.Data.Models.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Exception")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTemplate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Shop.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Data.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("StockItemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StockItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Shop.Data.Models.StockItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("GoodId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("StoreId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("Shop.Data.Models.Store", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Shop.Data.Models.Type", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Shop.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ConfirmString")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shop.Data.Models.Basket", b =>
                {
                    b.HasOne("Shop.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Data.Models.BrandType", b =>
                {
                    b.HasOne("Shop.Data.Models.Brand", "Brand")
                        .WithMany("BrandTypes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.Type", "Type")
                        .WithMany("BrandTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Shop.Data.Models.Good", b =>
                {
                    b.HasOne("Shop.Data.Models.Brand", "Brand")
                        .WithMany("Goods")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.Type", "Type")
                        .WithMany("Goods")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Shop.Data.Models.Order", b =>
                {
                    b.HasOne("Shop.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Data.Models.OrderItem", b =>
                {
                    b.HasOne("Shop.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.StockItem", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("Shop.Data.Models.StockItem", b =>
                {
                    b.HasOne("Shop.Data.Models.Good", "Good")
                        .WithMany("StockItems")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.Store", "Store")
                        .WithMany("StockItems")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Shop.Data.Models.Brand", b =>
                {
                    b.Navigation("BrandTypes");

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Shop.Data.Models.Good", b =>
                {
                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("Shop.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Shop.Data.Models.Store", b =>
                {
                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("Shop.Data.Models.Type", b =>
                {
                    b.Navigation("BrandTypes");

                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
