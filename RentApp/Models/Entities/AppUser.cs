using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace RentApp.Models.Entities
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength (100)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
       
        public string UserPicture { get; set; }

    }
}