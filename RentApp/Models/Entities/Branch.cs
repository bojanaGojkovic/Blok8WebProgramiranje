using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RentApp.Models.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        
        public string BranchPicture { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}