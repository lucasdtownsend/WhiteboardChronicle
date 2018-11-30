using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class TaggedWhiteboard
    {
        public int TaggedWhiteboardID { get; set; }
        public int TagID { get; set; }
        public int WhiteboardItemID { get; set; }

        public virtual WhiteboardItem WhiteboardItem { get; set; }
        public virtual Tag Tag { get; set; }
    }
}