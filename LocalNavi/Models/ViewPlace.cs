using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class ViewPlace
    {
        public List<Category> Categories { get; set; }
        public List<City> Cities { get; set; }
    }
}