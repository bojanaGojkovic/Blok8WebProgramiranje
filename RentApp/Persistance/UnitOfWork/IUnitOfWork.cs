using RentApp.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Persistance.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository Services { get; set; }
        IAppUserRepository AppUsers { get; set; }
        IBranchRepository Branches { get; set; }
        IPricelistRepository Pricelists { get; set; }
        IPricelistItemRepository PricelistItems { get; set; }
        IReservationRepository Reservations { get; set; }
        IUserFeedbackRepository UserFeedbacks { get; set; }
        IVehicleRepository Vehicles { get; set; }

        int Complete();
    }
}
