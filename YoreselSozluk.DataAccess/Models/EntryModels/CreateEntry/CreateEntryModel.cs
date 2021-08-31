using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.EntryModels.CreateEntry
{
    public class CreateEntryModel
    {
        public int UserId { get; set; }
        public int HeadingId { get; set; }
        public string Content { get; set; }
    }
}
