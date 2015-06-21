using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace learningMVC.Models
{
    public class Employee
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }

        public DateTime DOB { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}