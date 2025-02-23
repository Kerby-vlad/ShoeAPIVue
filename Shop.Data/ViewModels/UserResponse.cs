﻿using Shop.Data.Models;

namespace Shop.Data.ViewModels
{
    public class UserResponse
    {
        public long Id { get; set;}
        public string Email { get; set;}
        public string Address { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }

        public UserResponse(User u)
        {
            Id = u.Id;
            Email = u.Email;
            UserName = u.UserName;
            Address = u.Address;
            IsAdmin = u.IsAdmin;
            IsActive = u.IsActive;
        }

        public UserResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Address = user.Address;
            UserName = user.UserName;
            IsAdmin = user.IsAdmin;
            IsActive = user.IsActive;
            Token = token;
        }
    }
}