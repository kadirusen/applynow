﻿using System;
using System.Collections.Generic;

namespace ApplyNow.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        //public byte[] PasswordHash { get; set; }

        //public byte[] PasswordSalt { get; set; }

        public string Password { get; set; }

        public Resume Resume { get; set; }

    }
}
