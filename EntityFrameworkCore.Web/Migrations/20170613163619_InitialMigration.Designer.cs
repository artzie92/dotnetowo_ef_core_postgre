using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EntityFrameworkCore.Web.Models;

namespace EntityFrameworkCore.Web.Migrations
{
    [DbContext(typeof(DbEntities))]
    [Migration("20170613163619_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.ShopProduct", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ShopId");

                    b.HasKey("ProductId", "ShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopProduct");
                });

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.Employee", b =>
                {
                    b.HasOne("EntityFrameworkCore.Web.Models.Shop", "Shop")
                        .WithMany("Employees")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EntityFrameworkCore.Web.Models.ShopProduct", b =>
                {
                    b.HasOne("EntityFrameworkCore.Web.Models.Product", "Product")
                        .WithMany("ProductShops")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EntityFrameworkCore.Web.Models.Shop", "Shop")
                        .WithMany("ShopProducts")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
