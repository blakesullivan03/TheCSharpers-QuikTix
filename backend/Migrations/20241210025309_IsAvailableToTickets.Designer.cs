﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TheCSharpers_QuikTix.Migrations
{
    [DbContext(typeof(QuikTixDbContext))]
    [Migration("20241210025309_IsAvailableToTickets")]
    partial class IsAvailableToTickets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketType")
                        .HasColumnType("TEXT");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReviewerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Showtime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdultTicketCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildTicketCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PurchaseTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("MovieId");

                    b.HasIndex("ShowtimeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Review", b =>
                {
                    b.HasOne("TheCSharpers_QuikTix.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Showtime", b =>
                {
                    b.HasOne("TheCSharpers_QuikTix.Models.Movie", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Ticket", b =>
                {
                    b.HasOne("TheCSharpers_QuikTix.Models.Cart", "Cart")
                        .WithMany("Tickets")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheCSharpers_QuikTix.Models.Movie", "Movie")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheCSharpers_QuikTix.Models.Showtime", "Showtime")
                        .WithMany()
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Movie");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Cart", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TheCSharpers_QuikTix.Models.Movie", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Showtimes");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}