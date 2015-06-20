using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Models
{
    public class UserModel
    {

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Incorrect Email Id")]
        public string Email { get; set; }

    }
}