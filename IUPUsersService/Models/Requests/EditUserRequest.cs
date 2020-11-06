using System;
namespace IUPUsersService.Models.Requests
{
    public class EditUserRequest
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Image { get; set; }
    }
}