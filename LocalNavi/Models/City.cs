using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(200), Required]
        public string Photo { get; set; }

        public List<Place> Places { get; set; }
    }
}