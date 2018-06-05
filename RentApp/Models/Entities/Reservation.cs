using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public AppUser User { get; set; }

        [ForeignKey("ReservedVehicle")]
        public int ReservedVehicleId { get; set; }

        [Required]
        public Vehicle ReservedVehicle { get; set; }

        [ForeignKey("StartingBranch")]
        public int StartingBranchId { get; set; }

        [Required]
        public Branch StartingBranch { get; set; }

        [ForeignKey("EndBranch")]
        public int EndBranchId { get; set; }

        [Required]
        public Branch EndBranch { get; set; }

        [Required]
        public DateTime TakeOverTime { get; set; }

        [Required]
        public DateTime ReturnTime { get; set; }

    }
}