using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class PlaceService
    {
        public int Id { get; set; }
        
        [Required]
        public int PlaceID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        public virtual Place Place { get; set; }
        public virtual Service Service { get; set; }
    }
}