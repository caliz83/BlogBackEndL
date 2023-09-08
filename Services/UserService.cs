using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using lizg1.BlogBackEndL.Controllers.Models.DTO;
using lizg1.BlogBackEndL.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace lizg1.BlogBackEndL.Services
{
    public class UserService : ControllerBase
    {
        //create a variable
        private readonly DataContext _context;

        //create a constructor
        public UserService(DataContext context) {
            _context = context;
        }

        //Helper function DoesUserExist(string username)
        public bool DoesUserExist(string? username) {
            //check the tables to see if username exists
            //if one item matches our condition, that item will be returned
            //if no item matches, it will return null
            //if multiple items match the condition, it will return an error

            // UserModel foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
            // if(foundUser != null) {
            //     //the user exists in the table
            // }
            // else {
            //     //the user does not exist
            // } see one-liner below

            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        public bool AddUser(CreateAccountDTO UserToAdd) {

            bool result = false;
            //check if the user already exists
            if(!DoesUserExist(UserToAdd.Username)){
                //we need to create a new instance (aka object) of our UserModel
                UserModel newUser = new UserModel();

                var newHashedPassword = HashPassword(UserToAdd.Password);

                newUser.Id = UserToAdd.Id;

                newUser.Username = UserToAdd.Username;

                newUser.Salt = newHashedPassword.Salt;

                newUser.Hash = newHashedPassword.Hash;

                //add user to our database
                _context.Add(newUser);

                //save the changes
                _context.SaveChanges();
            } //else
            return result;
            //if they don't exist, we need to add account
            //else throw a false
        }

        public PasswordDTO HashPassword(string password) {
            //create a password DTO - this is what we are going to return
            //we need to create a new instance of our PasswordDTO
            PasswordDTO newHashedPassword = new PasswordDTO();

            //salt bytes size of our SaltBytes which is 64 bytes
            byte[] SaltBytes = new byte[64];

            //RNGCryptoServiceProvider is an instance of system.security.cryptography - generates random numbers
            var provider = new RNGCryptoServiceProvider();
            //RNGCryptoServiceProvider is too long so using 'var' lol

            //now we are going to exclude all the zeros
            provider.GetNonZeroBytes(SaltBytes);
            //encrypts the 64 string
            var Salt = Convert.ToBase64String(SaltBytes);

            //we will use this to create the hash - 1st argument is the password, 2nd is bytes, 3rd is iterations
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);

            //now we need to create our hash
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            //return our new hash
            newHashedPassword.Salt = Salt;

            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt) {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }

        public IEnumerable<UserModel>GetAllUsers() {
            return _context.UserInfo;
        }

        public UserModel GetUserByUsername(string? username) {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }
        public IActionResult Login(LoginDTO user)
        {
            IActionResult Result = Unauthorized();
            if(DoesUserExist(user.Username))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superDuperSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            Result = Ok(new { Token = tokenString });
            }

            return Result;

        }

        
    }
}