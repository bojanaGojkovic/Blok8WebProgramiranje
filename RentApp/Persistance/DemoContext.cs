using RentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentApp.Persistance
{
    public class DemoContext : DbContext
    {
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Branch> BranchOffices { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Pricelist> Pricelists { get; set; }
        public virtual DbSet<PricelistItem> PricelistItems { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }

        public DemoContext() : base("name=DemoConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}