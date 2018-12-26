using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalNavi.Models
{
    public class Reaction
    {
        public int Id { get; set; }

        public int CommentID { get; set; }

        public int UserID { get; set; }

        public bool Type { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}