using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimuVladProiect.Models;

namespace TimuVladProiect.Data
{
    public class ServiceContext: DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<DoctorService>().ToTable("DoctorService");
            modelBuilder.Entity<DoctorService>().HasKey(c => new { c.ServiceID, c.DoctorID });//configureaza cheia primara compusa
        }
    }
}
