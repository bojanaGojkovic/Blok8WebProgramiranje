using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class PricelistItem
    {
        public int Id { get; set; }

        [Required]
        public Vehicle VehicleItem { get; set; }

        public double VehiclePrice { get; set; }

        [Required]
        public Pricelist VehiclePricelist { get; set; }
    }
}