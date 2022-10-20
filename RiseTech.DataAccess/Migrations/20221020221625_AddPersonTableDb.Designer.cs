﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiseTech.DataAccess.Data;

namespace RiseTech.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221020221625_AddPersonTableDb")]
    partial class AddPersonTableDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RiseTech.Entities.Models.ContactInfo", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InformationType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PersonUUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UUID");

                    b.HasIndex("PersonUUID");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("RiseTech.Entities.Models.Person", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("RiseTech.Entities.Models.Report", b =>
                {
                    b.Property<int>("KayitliKisi")
                        .HasColumnType("int");

                    b.Property<int>("KayitliTelefonNumarasi")
                        .HasColumnType("int");

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("RiseTech.Entities.Models.ContactInfo", b =>
                {
                    b.HasOne("RiseTech.Entities.Models.Person", "Person")
                        .WithMany("ContactInfos")
                        .HasForeignKey("PersonUUID");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("RiseTech.Entities.Models.Person", b =>
                {
                    b.Navigation("ContactInfos");
                });
#pragma warning restore 612, 618
        }
    }
}