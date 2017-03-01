using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chatter.Models
{
    public class ChatFeed
    {
        [Key]
        public int TweetID { get; set; }
        public string TweetContent { get; set; }
        public DateTime TweetDate { get; set; }
        public virtual ApplicationUser ApplicationUser02 { get; set; }
    }
}