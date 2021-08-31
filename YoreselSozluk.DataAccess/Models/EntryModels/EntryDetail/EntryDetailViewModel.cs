using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.EntryModels.EntryDetail
{
    public class EntryDetailViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public EntryDetailUser User {  get; set; }

    }

    public class EntryDetailUser
    {
        public string UserName { get; set; }
    }
}
