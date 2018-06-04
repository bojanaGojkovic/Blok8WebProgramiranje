using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleModel { get; set; }

        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

       
        public uint YearOfProduction { get; set; }

        [Required]
        public string VehiclePicture { get; set; }

        [Required]
        public string Description { get; set; }
    }
}