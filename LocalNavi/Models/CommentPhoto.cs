﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class CommentPhoto
    {
        public int Id { get; set; }

        [Required]
        public int CommentID { get; set; }

        [StringLength(200), Required]
        public string Photo { get; set; }

        public virtual Comment Comment { get; set; }
    }
}