using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentApp.Models.Entities
{
    public class UserType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }
         
    }
}