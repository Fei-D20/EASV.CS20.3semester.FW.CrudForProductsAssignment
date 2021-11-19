using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        User CreateUser(User user);
        User GetUserById(int id);
        User RemoveUser(int id);
        User UpdateUser(User user);
    }
}