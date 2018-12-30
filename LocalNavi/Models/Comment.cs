using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        public short Rating { get; set; }

        [StringLength(140), Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PlaceID { get; set; }

        [Required]
        public int UserID { get; set; }

        public virtual Place Place { get; set; }
        public virtual User User { get; set; }

        public List<Reaction> Reactions { get; set; }
        public List<CommentPhoto> CommentPhotos { get; set; }
    }
}