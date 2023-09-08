using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lizg1.BlogBackEndL.Controllers.Models.DTO;
using lizg1.BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //create a variable with a type service (User service)
        private readonly UserService _data;

        //create a constructor
        public UserController(UserService dataFromService) {
            _data = dataFromService;
        }

        //Add a user
        [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd) {
            return _data.AddUser(UserToAdd);
        }
            //check if user already exists
            //if user does not exist, create an account
            //else throw an error
        
    //Login
    [HttpPost("Login")] // -  move right under the public IEnumable function, outside its brackets but still inside the ones it's inside
    public IActionResult Login([FromBody] LoginDTO User) {
        return _data.Login(User);
    }
    }
    //Login
    //Update user account
    //Delete user account

}