﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Starbucks_Calorimeter.Models;

#nullable disable

namespace Starbucks_Calorimeter.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.BottledDrink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BottledDrinks");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Cream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Creams");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Dessert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Desserts");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Coffeine")
                        .HasColumnType("float");

                    b.Property<int?>("CreamId")
                        .HasColumnType("int");

                    b.Property<int?>("EspressoId")
                        .HasColumnType("int");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<int?>("MilkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreamId");

                    b.HasIndex("EspressoId");

                    b.HasIndex("MilkId");

                    b.HasIndex("SizeId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Espresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Coffeine")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Espressoes");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.FoodInPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FoodInPackages");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.LunchAndBreakfast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LunchAndBreakfasts");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Milk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Milks");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Pastry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pastry");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Syrop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohidrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fats")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Syrops");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Starbucks_Calorimeter.Models.Entity.Drink", b =>
                {
                    b.HasOne("Starbucks_Calorimeter.Models.Entity.Cream", "Cream")
                        .WithMany()
                        .HasForeignKey("CreamId");

                    b.HasOne("Starbucks_Calorimeter.Models.Entity.Espresso", "Espresso")
                        .WithMany()
                        .HasForeignKey("EspressoId");

                    b.HasOne("Starbucks_Calorimeter.Models.Entity.Milk", "Milk")
                        .WithMany()
                        .HasForeignKey("MilkId");

                    b.HasOne("Starbucks_Calorimeter.Models.Entity.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cream");

                    b.Navigation("Espresso");

                    b.Navigation("Milk");

                    b.Navigation("Size");
                });
#pragma warning restore 612, 618
        }
    }
}
