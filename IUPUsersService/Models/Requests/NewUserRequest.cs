﻿using System;
namespace IUPUsersService.Models.Requests
{
    public class NewUserRequest
    {
        public string Kennitala { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}