using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class PlaceService
    {
        public int Id { get; set; }
        
        public int PlaceID { get; set; }

        public int ServiceID { get; set; }

        public virtual Place Place { get; set; }
        public virtual Service Service { get; set; }
    }
}