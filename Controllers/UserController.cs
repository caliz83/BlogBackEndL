using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Models.DTO;
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

        //Get user by username
        [HttpGet("GetUserByUsername/{username}")]
        public UserIdDTO GetUserIdDTOByUsername(string username) {
            return _data.GetUserIdDTOByUsername(username); //remember to generate method which will appear in UserService.cs
        }

        //Add a user
        [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd) {
            return _data.AddUser(UserToAdd);
        }
            //check if user already exists
            //if user does not exist, create an account
            //else throw an error

            //Gety Users
            // [HttpGet("GetAllUsers")]
            // public IEnumerable<UserModel> GetAllUsers() { 
            //     return _data.GetAllUsers();
            //  }
        
    //Login
    [HttpPost("Login")] // -  move right under the public IEnumable function, outside its brackets but still inside the ones it's inside
    public IActionResult Login([FromBody] LoginDTO User) {
        return _data.Login(User);
    }

    //Delete user account
    [HttpPost("DeleteUser/{userToDelete}")]

    public bool DeleteUser(string userToDelete){
        return _data.DeleteUser(userToDelete);
    }

    //Update user account
    [HttpPost("UpdateUser")] //can also do the same way as DeleteUser above but this way is possibly better (less)

    public bool UpdateUser(int id, string username){
        return _data.UpdateUsername(id, username);
    }

    }
}