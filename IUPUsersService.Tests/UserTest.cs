using System;
using IUPUsersService.Models;
using Moq;
using Xunit;

namespace IUPUsersService.Tests
{
    public class UserTest
    {
        private readonly Mock<User> _User;

        public UserTest()
        {
            _User = new Mock<User>("William", "Paciaroni", DateTime.ParseExact("30/05/1997", "dd/MM/yyyy", null));
        }

        [Fact]
        public string GetName()
        {
            return _User.Object.Name;

        }

        [Fact]
        public string GetSurname()
        {
            return _User.Object.Surname;

        }

        [Fact]
        public DateTime GetBirthdayAsDate()
        {
            return _User.Object.Birthday;

        }

        [Fact]
        public string GetBirthdayAsString()
        {

            return _User.Object.Birthday.ToString();

        }
    }
}
