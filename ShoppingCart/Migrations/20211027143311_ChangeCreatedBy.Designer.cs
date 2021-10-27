﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCart;

namespace ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    [Migration("20211027143311_ChangeCreatedBy")]
    partial class ChangeCreatedBy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ShoppingCart.Models.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TimeUpdated")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Status = 0,
                            TimeCreated = new DateTime(2021, 1, 1, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Status = 2,
                            TimeCreated = new DateTime(2021, 1, 1, 10, 10, 10, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TimeUpdated")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CartId = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Description = "Description1",
                            Name = "Name1",
                            TimeCreated = new DateTime(2021, 1, 2, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CartId = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Description = "Description2",
                            Name = "Name2",
                            TimeCreated = new DateTime(2021, 1, 3, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            CartId = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Description = "Description3",
                            Name = "Name3",
                            TimeCreated = new DateTime(2021, 1, 4, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            CartId = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Description = "Description4",
                            Name = "Name4",
                            TimeCreated = new DateTime(2021, 1, 5, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            CartId = 1,
                            CreatedBy = "auth0|617946b7ed3a290068b82013",
                            Description = "Description5",
                            Name = "Name5",
                            TimeCreated = new DateTime(2021, 1, 6, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            CartId = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Description = "Description6",
                            Name = "Name6",
                            TimeCreated = new DateTime(2021, 1, 7, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            CartId = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Description = "Description7",
                            Name = "Name7",
                            TimeCreated = new DateTime(2021, 1, 8, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            CartId = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Description = "Description8",
                            Name = "Name8",
                            TimeCreated = new DateTime(2021, 1, 9, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            CartId = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Description = "Description9",
                            Name = "Name9",
                            TimeCreated = new DateTime(2021, 1, 10, 10, 10, 10, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            CartId = 2,
                            CreatedBy = "auth0|6179475e1c278900683507fd",
                            Description = "Description10",
                            Name = "Name10",
                            TimeCreated = new DateTime(2021, 1, 11, 10, 10, 10, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.Entity.CartItem", b =>
                {
                    b.HasOne("ShoppingCart.Models.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("ShoppingCart.Models.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
