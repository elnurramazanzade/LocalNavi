using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class WorkHour
    {
        public int Id { get; set; }

        [Required]
        public int DayNo { get; set; }

        [Required]
        public TimeSpan OpenHour { get; set; }

        [Required]
        public TimeSpan CloseHour { get; set; }

        [Required]
        public int PlaceID { get; set; }

        public virtual Place Place { get; set; }
    }
}