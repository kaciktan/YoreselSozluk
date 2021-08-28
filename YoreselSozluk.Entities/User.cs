using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.Entities
{
    public class User
    {
        public int Id {  get; set; }
        public string UserName {  get; set; }
        public string Email {  get; set; }
        public string Password {  get; set; }
        public string Roles { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

    }
}
