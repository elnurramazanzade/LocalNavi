﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Place
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Slogan { get; set; }

        [Column(TypeName = "ntext")]
        public string Desc { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string Lat { get; set; }

        [StringLength(50)]
        public string Lng { get; set; }

        public int CategoryID { get; set; }

        public int CityID { get; set; }

        public int UserID { get; set; }

        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }

        public List<Comment> Comments { get; set; }
        public List<PlacePhoto> PlacePhotos { get; set; }
        public List<PlaceService> PlaceServices { get; set; }
        public List<WorkHour> WorkHours { get; set; }
    }
}