using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Login { get; set; }

        [StringLength(100), Required]
        public string Password { get; set; }

        [Required]
        public byte Role { get; set; }
    }
}