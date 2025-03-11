﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20250311132230_BooksAddData")]
    partial class BooksAddData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("PublicationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J.D. Salinger",
                            PublicationDate = new DateOnly(1951, 7, 16),
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            PublicationDate = new DateOnly(1960, 7, 11),
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            PublicationDate = new DateOnly(1949, 6, 8),
                            Title = "1984"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jane Austen",
                            PublicationDate = new DateOnly(1813, 1, 28),
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 5,
                            Author = "F. Scott Fitzgerald",
                            PublicationDate = new DateOnly(1925, 4, 10),
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Herman Melville",
                            PublicationDate = new DateOnly(1851, 10, 18),
                            Title = "Moby-Dick"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Leo Tolstoy",
                            PublicationDate = new DateOnly(1869, 1, 1),
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 8,
                            Author = "J.R.R. Tolkien",
                            PublicationDate = new DateOnly(1937, 9, 21),
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Fyodor Dostoevsky",
                            PublicationDate = new DateOnly(1866, 1, 1),
                            Title = "Crime and Punishment"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Homer",
                            PublicationDate = new DateOnly(701, 1, 1),
                            Title = "The Odyssey"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
