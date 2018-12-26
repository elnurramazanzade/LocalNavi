using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class WorkHour
    {
        public int Id { get; set; }

        public int DayNo { get; set; }

        public TimeSpan OpenHour { get; set; }

        public TimeSpan CloseHour { get; set; }

        public int PlaceID { get; set; }

        public virtual Place Place { get; set; }
    }
}