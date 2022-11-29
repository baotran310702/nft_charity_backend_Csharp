﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nft_project.Data;

#nullable disable

namespace nft_project.Migrations.TransDB
{
    [DbContext(typeof(TransDBContext))]
    [Migration("20221119122812_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("nft_project.Models.Trans", b =>
                {
                    b.Property<int>("trans_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trans_id"), 1L, 1);

                    b.Property<string>("account_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("createAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("is_nft_trans")
                        .HasColumnType("int");

                    b.HasKey("trans_id");

                    b.ToTable("Trans");
                });
#pragma warning restore 612, 618
        }
    }
}