﻿using System;

namespace Entities.Support
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public bool IsConfirmed { get; set; }

        public UserModel(string email, string password)
        {
            Id = 0;
            Email = email;
            Password = password;
            RoleId = 1;
            IsConfirmed = false;
        }
    }
}