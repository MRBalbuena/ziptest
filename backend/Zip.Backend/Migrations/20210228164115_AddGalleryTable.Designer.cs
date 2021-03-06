﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Zip.Backend.Data;

namespace Zip.Backend.Migrations
{
    [DbContext(typeof(GuestBookContext))]
    [Migration("20210228164115_AddGalleryTable")]
    partial class AddGalleryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Zip.Backend.Data.Gallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnName("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_gallery");

                    b.ToTable("gallery");
                });

            modelBuilder.Entity("Zip.Backend.Data.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .IsConcurrencyToken()
                        .HasColumnName("created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_guest_book");

                    b.ToTable("guest_book");
                });
#pragma warning restore 612, 618
        }
    }
}
