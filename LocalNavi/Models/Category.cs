using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(200), Required]
        public string Icon { get; set; }

        public List<CategoryService> CategoryServices { get; set; }
        public List<Place> Places { get; set; }
    }
}