﻿namespace Entities.Support
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
    }
}