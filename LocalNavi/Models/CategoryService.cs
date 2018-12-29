using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class CategoryService
    {
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Service Service { get; set; }
    }
}