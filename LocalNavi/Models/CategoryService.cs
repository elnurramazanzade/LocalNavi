using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class CategoryService
    {
        public int Id { get; set; }

        public int CategoryID { get; set; }

        public int ServiceID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Service Service { get; set; }
    }
}