using DataAccess;
using DataModels;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDbo> _userRepository;
        public UserService(IRepository<UserDbo> userRepository)
        {
            _userRepository = userRepository;
        }
        public UserModel Authenticate(string username, string password)
        {

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(
                Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = _userRepository.GetAll()
                .SingleOrDefault(x => x.UserName == username &&
                x.Password == hashedPassword);

            if (user == null) return null;

            UserModel userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Address = user.Address
            };

            return userModel;
        }

        public void RegisterUser(RegisterModel model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(
                Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            UserDbo user = new UserDbo()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = hashedPassword,
                Address = model.Address
            };

            _userRepository.Add(user);
        }
    }
}
