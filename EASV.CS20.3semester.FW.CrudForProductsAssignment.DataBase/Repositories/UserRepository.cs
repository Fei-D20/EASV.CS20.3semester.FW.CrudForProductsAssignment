using System.Collections.Generic;
using System.Linq;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.Entities;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;


    namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _ctx;
        private List<UserEntity> _users = new List<UserEntity>();
        int _id = 1;

        public UserRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetUsers()
        {
            var selectQuery = _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Password = userEntity.Password,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt,
                Role = userEntity.Role
                
            });
            return selectQuery.ToList();
        }

        public User CreateUser(User user)
        {
            UserEntity userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Role = user.Role
            };
            _ctx.Users.Add(userEntity);
            _ctx.SaveChanges();
            return user;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Password = userEntity.Password,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt,
                Role = userEntity.Role
            }).FirstOrDefault(u => u.Id == id);
        }

        public User RemoveUser(int id)
        {
            var entity = _ctx.Users.Remove(new UserEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new User
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                PasswordHash = entity.PasswordHash,
                PasswordSalt = entity.PasswordSalt,
                Role = entity.Role
            };
        }

        public User UpdateUser(User user)
        {
            var entity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Role = user.Role
            };
            _ctx.Users.Update(entity);
            _ctx.SaveChanges();
            return user;
        }
    }
}