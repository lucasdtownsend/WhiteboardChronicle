using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class WhiteboardItem
    {
        public int WhiteboardItemID { get; set; }
        public string ImageURL { get; set; }
        public int UserID { get; set; }

        public WhiteboardItem()
        {
            UploadDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UploadDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TaggedWhiteboard> TaggedWhiteboards { get; set; }
    }
}