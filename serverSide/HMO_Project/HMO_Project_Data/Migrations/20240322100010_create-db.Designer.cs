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
    [Migration("20240322100010_create-db")]
    partial class createdb
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

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("diagnosis")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("recovery")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.ToTable("KoronaDiseasesData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("KoronaDiseaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("houseNumber")
                        .HasColumnType("int");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobilePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KoronaDiseaseId")
                        .IsUnique()
                        .HasFilter("[KoronaDiseaseId] IS NOT NULL");

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

                    b.Property<int>("VaccineProducerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("recieveDate")
                        .HasColumnType("DATE");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VaccineProducersData");
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Member", b =>
                {
                    b.HasOne("HMO_Project.Core.Entities.KoronaDisease", "KoronaDisease")
                        .WithOne("Member")
                        .HasForeignKey("HMO_Project.Core.Entities.Member", "KoronaDiseaseId");

                    b.Navigation("KoronaDisease");
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

            modelBuilder.Entity("HMO_Project.Core.Entities.KoronaDisease", b =>
                {
                    b.Navigation("Member")
                        .IsRequired();
                });

            modelBuilder.Entity("HMO_Project.Core.Entities.Member", b =>
                {
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
