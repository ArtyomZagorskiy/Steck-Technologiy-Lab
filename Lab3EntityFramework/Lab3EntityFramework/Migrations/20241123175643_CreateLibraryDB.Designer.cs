﻿// <auto-generated />
using System;
using Lab3EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3EntityFramework.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20241123175643_CreateLibraryDB")]
    partial class CreateLibraryDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab3EntityFramework.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReaderId");

                    b.ToTable("libraryBooks");
                });

            modelBuilder.Entity("Lab3EntityFramework.Reader", b =>
                {
                    b.Property<int>("ReaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReaderId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReaderId");

                    b.ToTable("readers");
                });

            modelBuilder.Entity("Lab3EntityFramework.Book", b =>
                {
                    b.HasOne("Lab3EntityFramework.Reader", null)
                        .WithMany("books")
                        .HasForeignKey("ReaderId");
                });

            modelBuilder.Entity("Lab3EntityFramework.Reader", b =>
                {
                    b.Navigation("books");
                });
#pragma warning restore 612, 618
        }
    }
}
