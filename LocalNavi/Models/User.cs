using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string Surname { get; set; }

        [StringLength(50), Required]
        public string Email { get; set; }

        [StringLength(100), Required]
        public string Password { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Place> Places { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}