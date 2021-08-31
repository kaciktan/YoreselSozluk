using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.EntryModels.GetEntries
{
    public class EntriesViewModel
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public EntriesUser User { get; set; }
    }

    public class EntriesUser
    {
        public string UserName { get; set; }
    }
}
