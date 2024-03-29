﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VistaBasket.Catalog.Data;

#nullable disable

namespace VistaBasket.Catalog.Data.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20240227113528_update-baseentity")]
    partial class updatebaseentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VistaBasket.Catalog.Entities.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdon");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("updatedby");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedon");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });
#pragma warning restore 612, 618
        }
    }
}
