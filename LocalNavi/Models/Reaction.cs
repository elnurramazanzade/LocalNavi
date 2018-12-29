using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Reaction
    {
        public int Id { get; set; }

        [Required]
        public int CommentID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public bool Type { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}