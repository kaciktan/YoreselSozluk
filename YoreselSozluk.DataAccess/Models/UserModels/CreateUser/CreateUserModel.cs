﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.UserModels.CreateUser
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }

    }
}
