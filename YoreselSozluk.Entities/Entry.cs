using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoreselSozluk.Entities
{
    public class Entry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public int UserId { get; set; }
        public int HeadingId { get; set; }
        public string Content { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
    }
}
