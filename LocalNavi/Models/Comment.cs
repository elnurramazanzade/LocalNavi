using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public short Rating { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int PlaceID { get; set; }

        public int UserID { get; set; }

        public virtual Place Place { get; set; }
        public virtual User User { get; set; }

        public List<Reaction> Reactions { get; set; }
        public List<CommentPhoto> CommentPhotos { get; set; }
    }
}