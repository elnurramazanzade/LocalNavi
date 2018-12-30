using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Admin
    {
        public enum RoleType : byte
        {
            SuperAdmin = 1,
            Admin = 2
        }

        public int Id { get; set; }

        [StringLength(50), Required]
        public string Login { get; set; }

        [StringLength(100), Required]
        public string Password { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string Surname { get; set; }

        [Required]
        public RoleType Role { get; set; }
    }
}