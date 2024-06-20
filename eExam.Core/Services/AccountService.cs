using DataAccess.Entities;
using DataAccess.Interfaces;
using eExam.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eExam.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<AccountService> _logger;
        public AccountService(IUserRepository repo, ILogger<AccountService> logger)
        {
            _repository = repo;
            _logger = logger;
        }
        public string UserLogin(string username, string password)
        {
            _logger.LogInformation("AccountService:Stared method UserLogin()");

            string message = string.Empty;
            bool isSuccess = true;
            try
            {
                var existingUser = _repository.GetUser(username);
                if (existingUser == null)
                {
                    message = "User Not Found";
                    isSuccess= false;
                }
                else
                {
                    using var hmac=new HMACSHA256(existingUser.PasswordSalt);
                    var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for(int i = 0;i< passwordHash.Length; i++)
                    {
                        if (passwordHash[i] != existingUser.PasswordHash[i])
                        {
                            message = "Incorrect Password";
                            isSuccess= false;
                            break;
                        }
                    }
                }
                if(isSuccess)
                {
                    //TODO
                    message = "Login Success";
                }
            }
            
    
            catch(Exception ex)
            {
                _logger.LogError("Error:" + ex.Message);
                message = "Login Failed";
            }
            return message;
        }

        public string UserRegistration(string username, string password, string userType)
        {
            _logger.LogInformation("AccountService:Stared method UserRegistration()");
            string message = string.Empty;
            try
            {
                using var hmac=new HMACSHA256();
                
                var passwordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var passwordSalt = hmac.Key;

                User user = new User();
                user.UserName = username;
                user.UserType = userType;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Email = "Vijay@gmail.com";
                user.PhoneNo = "9988776655";
                user.CreatedOn = DateTime.Now;

                _repository.Add(user);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error:"+ex.Message);
                message = "Registration Failed";
            }
            message = "Registration Success";
            _logger.LogInformation("AccountService:End method UserRegistration()");
            return message;
        }
    }
}
