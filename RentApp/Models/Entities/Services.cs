using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RentApp.Models.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }

        public double AverageRating { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public List<Branch> Branches{ get; set; }
    }
}