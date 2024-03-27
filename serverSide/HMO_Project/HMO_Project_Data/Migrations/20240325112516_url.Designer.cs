﻿// <auto-generated />
using System;
using HMO_Project_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240325112516_url")]
    partial class url
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HMO_Project.Core.Entities.KoronaDisease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DiagnosisDate")
                        .HasColumnType("DATE");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RecoveryDate")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("KoronaDiseasesData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KoronaDiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MembersData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfVaccination")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecieveDate")
                        .HasColumnType("DATE");

                    b.Property<int>("VaccineProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VaccineProducerId");

                    b.ToTable("VaccinationsData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.VaccineProducer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VaccineProducersData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.KoronaDisease", b =>
                {
                    b.HasOne("HMO_Project.Core.Entities.Member", "Member")
                        .WithOne("KoronaDisease")
                        .HasForeignKey("HMO_Project.Core.Entities.KoronaDisease", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Vaccination", b =>
                {
                    b.HasOne("HMO_Project.Core.Entities.Member", "Member")
                        .WithMany("Vaccinations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMO_Project.Core.Entities.VaccineProducer", "VaccineProducer")
                        .WithMany("Vaccinations")
                        .HasForeignKey("VaccineProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("VaccineProducer");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Member", b =>
                {
                    b.Navigation("KoronaDisease");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.VaccineProducer", b =>
                {
                    b.Navigation("Vaccinations");
                });
#pragma warning restore 612, 618
        }
    }
}
