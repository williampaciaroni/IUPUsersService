using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IUPUsersService.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IUPUsersService.Models
{
    public class User : LazyEntity
    {

        public User(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        [Key]
        public int IdUser { get; set; }
        [Required]
        public string AppIdentityRef { get; set; }

        private AppIdentity _appIdentity;
        public virtual AppIdentity AppIdentity
        {
            get => lazyLoader.Load(this, ref _appIdentity);
            set => _appIdentity = value;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public User(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }


        public User(string name, string surname, DateTime birthday, string appIdentityRef)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
            this.AppIdentityRef = appIdentityRef;
        }
    }

    public class UserFiltered
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public UserFiltered(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }
    }
}