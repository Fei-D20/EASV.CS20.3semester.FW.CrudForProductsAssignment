using System;
using System.Collections.Generic;
using System.IO;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository userRepository)
        {
            _repo = userRepository ?? throw new InvalidDataException();
        }

        public List<User> GetUsers()
        {
           return _repo.GetUsers();
        }

        public User CreateUser(User user)
        {
            return _repo.CreateUser(user);
        }

        public User GetUserById(int id)
        {
            return _repo.GetUserById(id);
        }

        public User RemoveUser(int id)
        {
            return _repo.RemoveUser(id);
        }

        public User UpdateUser(User user)
        {
            return _repo.UpdateUser(user);
        }
    }
}