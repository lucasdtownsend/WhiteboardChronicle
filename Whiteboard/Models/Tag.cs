using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<TaggedWhiteboard> TaggedWhiteboards { get; set; }
    }
}