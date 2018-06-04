using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public AppUser User { get; set; }

        [Required]
        public Vehicle ReservedVehicle { get; set; }

        [Required]
        public Branch StartingBranch { get; set; }

        [Required]
        public Branch EndBranch { get; set; }

        [Required]
        public DateTime TakeOverTime { get; set; }

        [Required]
        public DateTime ReturnTime { get; set; }

    }
}