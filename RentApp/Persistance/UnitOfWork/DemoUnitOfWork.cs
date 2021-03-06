﻿using RentApp.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace RentApp.Persistance.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        [Dependency]
        public IServiceRepository Services { get; set; }

        [Dependency]
        public IAppUserRepository AppUsers { get; set; }

        [Dependency]
        public IBranchRepository Branches { get; set; }

        [Dependency]
        public IPricelistItemRepository PricelistItems { get; set; }

        [Dependency]
        public IPricelistRepository Pricelists { get; set; }

        [Dependency]
        public IReservationRepository Reservations { get; set; }

        [Dependency]
        public IUserFeedbackRepository UserFeedbacks { get; set; }

        [Dependency]
        public IVehicleRepository Vehicles { get; set; }


        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}