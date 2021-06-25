using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class ConversationOBJ
    {
        public string token { get; set; }
        public string OwnerTable { get; set; }
        public int TopicId { get; set; }
        public string Content { get; set; }
    }
}