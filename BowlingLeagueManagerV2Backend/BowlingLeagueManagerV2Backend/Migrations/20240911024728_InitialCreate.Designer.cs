﻿// <auto-generated />
using BowlingLeagueManagerV2Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BowlingLeagueManagerV2Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240911024728_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BowlingLeagueManagerV2Backend.Models.Bowler", b =>
                {
                    b.Property<int>("BowlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BowlerId"));

                    b.Property<int>("Average")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighestGame")
                        .HasColumnType("int");

                    b.Property<int>("HighestSeries")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalGamesBowled")
                        .HasColumnType("int");

                    b.Property<int>("TotalPins")
                        .HasColumnType("int");

                    b.HasKey("BowlerId");

                    b.ToTable("Bowlers");
                });
#pragma warning restore 612, 618
        }
    }
}
