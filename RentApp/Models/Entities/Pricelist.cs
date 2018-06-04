using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class Pricelist
    {
        public int Id{ get; set; }

        [Required]
        public DateTime TimeOfValidity  { get; set; }

        [Required]
        public Service PricelistService { get; set; }
    }
}