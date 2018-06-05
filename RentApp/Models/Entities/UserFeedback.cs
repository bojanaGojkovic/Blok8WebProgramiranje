using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class UserFeedback
    {
        public int Id { get; set; }

        [ForeignKey("RatedService")]
        public int RatedServiceId { get; set; }
        [Required]
        public Service RatedService { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public AppUser User { get; set; }

        [RangeAttribute(1,5)]
        public int UserRating { get; set; }


        public string UserComment { get; set; }

    }
}