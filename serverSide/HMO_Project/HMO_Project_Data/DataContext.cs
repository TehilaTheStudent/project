using HMO_Project.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Project_Data
{
    public class DataContext:DbContext  
    {
        public DbSet<Vaccination> VaccinationsData  { get; set; }
        public DbSet<Member> MembersData  { get; set; }
        public DbSet<VaccineProducer> VaccineProducersData  { get; set; }
        public DbSet<KoronaDisease> KoronaDiseasesData  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HMO_DataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasOne(member => member.KoronaDisease)
                .WithOne(koronaDisease => koronaDisease.Member)
                .HasForeignKey<Member>(member => member.KoronaDiseaseId)
                .IsRequired(false); // Make the foreign key nullable

        

            modelBuilder.Entity<KoronaDisease>()
                .HasOne(koronaDisease => koronaDisease.Member)
                .WithOne(member => member.KoronaDisease)
                .HasForeignKey<KoronaDisease>(koronaDisease => koronaDisease.MemberId)
                .IsRequired(); // Make the foreign key non-nullable for Details
        }
    }
}
