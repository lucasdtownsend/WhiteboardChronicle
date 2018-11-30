using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int TeamID { get; set; }

        // Foreign Key
        public virtual Team Team { get; set; }
        public virtual ICollection<WhiteboardItem> WhiteboardItems { get; set; }
    }
}