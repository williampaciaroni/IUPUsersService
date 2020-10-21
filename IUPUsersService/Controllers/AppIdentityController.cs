using System;
using System.Linq;
using IUPUsersService.Context;
using IUPUsersService.Models;
using IUPUsersService.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IUPUsersService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppIdentityController : ControllerBase
    {

        private readonly IUPUsersContext iupUsersContext;
        public IConfiguration Configuration { get; }

        public AppIdentityController(IUPUsersContext iupUsersContext, IConfiguration configuration)
        {
            this.iupUsersContext = iupUsersContext;
            Configuration = configuration;
        }

        [HttpPost("registerUser")]
        public IActionResult RegisterUser([FromBody] NewUserRequest newUserRequest)
        {
            if (newUserRequest.Kennitala == null || newUserRequest.Password == null)
            {
                return BadRequest();
            }

            if (iupUsersContext.AppIdentities.FirstOrDefault(a => a.Kennitala == newUserRequest.Kennitala) != null)
            {

                return StatusCode(409, "User with Kennitala " + newUserRequest.Kennitala + " already exists.");
            }
            else
            {
                return CreateNewUser(newUserRequest);
            }
        }

        [HttpGet("kennitalaAvailable/{kennitala}")]
        public IActionResult ExistUser([FromRoute] string kennitala)
        {
            AppIdentity aI = iupUsersContext.AppIdentities.FirstOrDefault(a => a.Kennitala == kennitala);

            if (aI == null)
            {
                return NoContent();
            }
            else
            {
                return Ok();
            }
        }

        private IActionResult CreateNewUser(NewUserRequest newUserRequest)
        {
            try
            {
                User u = new User(
                    newUserRequest.Name,
                    newUserRequest.Surname,
                    DateTime.ParseExact(newUserRequest.Birthday, "dd/MM/yyyy", null),
                    newUserRequest.Kennitala);

                iupUsersContext.Users.Add(u);
                AppIdentity aId = new AppIdentity(newUserRequest.Kennitala, BCrypt.Net.BCrypt.HashPassword(newUserRequest.Password));
                iupUsersContext.AppIdentities.Add(aId);
                iupUsersContext.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                //Eccezione da gestire nel modo corretto
                return StatusCode(500);
            }

        }
    }
}