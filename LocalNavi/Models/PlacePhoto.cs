﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class PlacePhoto
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        public int PlaceID { get; set; }

        public virtual Place Place { get; set; }
    }
}