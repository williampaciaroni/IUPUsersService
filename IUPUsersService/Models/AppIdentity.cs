using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IUPUsersService.Models
{
    public class AppIdentity : LazyEntity
    {

        public AppIdentity(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        [Key]
        public string Kennitala { get; set; }
        [Required]
        public string Password { get; set; }

        private User _user;
        public virtual User User
        {
            get => lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        public AppIdentity()
        { }

        public AppIdentity(string kennitala, string password)
        {
            this.Kennitala = kennitala;
            this.Password = password;
        }
    }
}