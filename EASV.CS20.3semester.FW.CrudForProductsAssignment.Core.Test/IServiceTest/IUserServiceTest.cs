using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test.IServiceTest
{
    public class IUserServiceTest
    {
        #region Interface Avaliable Test

        [Fact]
        public void IUserServiceTest_IsAvailable()
        {
            var mock = new Mock<IUserService>();
            Assert.NotNull(mock.Object);
        }
        #endregion

        #region Get Method Test

        [Fact]
        public void IUserServiceTest_GetAll_NoParameter_ReturnListOfUser()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(service => service.GetAll())
                .Returns(new List<User>());
            
            Assert.Equal(new List<User>(),mock.Object.GetAll());
        }

        [Fact]
        public void IUserServiceTest_GetById_ParameterId_ReturnUser()
        {
            var mock = new Mock<IUserService>();
            var user = new User()
            {
                Id = 1,
                Name = "name",
                Password = "123456",
                Type = UserType.Admin
            };
            mock.Setup(service => service.GetById(1))
                .Returns(user);
            Assert.Equal(user,mock.Object.GetById(1));
        }

        [Fact]
        public void IUserServiceTest_GetByName_ParameterName_ReturnUser()
        {
            var mock = new Mock<IUserService>();
            var user = new User()
            {
                Id = 1,
                Name = "name",
                Password = "123456",
                Type = UserType.Admin
            };
            mock.Setup(service => service.GetByName("name"))
                .Returns(user);
            Assert.Equal(user,mock.Object.GetByName("name"));
        }
        
        [Fact]
        public void IUserServiceTest_GetByType_ParameterType_ReturnUser()
        {
            var mock = new Mock<IUserService>();
            var user = new User()
            {
                Id = 1,
                Name = "name",
                Password = "123456",
                Type = UserType.Admin
            };
            mock.Setup(service => service.GetByType(UserType.Admin))
                .Returns(user);
            Assert.Equal(user,mock.Object.GetByType(UserType.Admin));
        }
        
        #endregion
        
    }

    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByName(string name);
        User GetByType(UserType type);
    }
}