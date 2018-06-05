using RentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RentApp.Persistance.Repository
{
    public class UserFeedbackRepository : Repository<UserFeedback, int>, IUserFeedbackRepository
    {
        public UserFeedbackRepository(DbContext context) : base(context)
        {
        }

        protected DemoContext DemoContext { get { return context as DemoContext; } }
    }
}