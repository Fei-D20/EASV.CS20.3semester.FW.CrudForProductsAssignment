#nullable enable
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test.ModelsTest
{
    public class UserTest
    {
        #region User

        [Fact]
        public void User_CanBeInitialize()
        {
            var user = new User();
            
            Assert.NotNull(user);
        }

        #endregion

        #region User Id

        [Fact]
        public void User_Id_SetId_GetId()
        {
            var user = new User()
            {
                Id = 1,
            };
            
            Assert.Equal(1,user.Id);
        }

        [Fact]
        public void User_Id_ShouldBeInt()
        {
            var user = new User();
            Assert.True(user.Id is int);
        }
        
        
        #endregion

        #region User Name

        [Fact]
        public void User_Name_SetName_GetName()
        {
            var user = new User()
            {
                Name = "name"
            };
            
            Assert.Equal("name",user.Name);
        }

        [Fact]
        public void User_Name_ShouldBeString()
        {
            var user = new User()
            {
                Name = "name"
            };
            Assert.True(user.Name is string);
        }
        
        [Fact]
        public void User_Name_CanBeNull()
        {
            var user = new User()
            {
                Name = null
            };
            Assert.Null(user.Name);
        }

        #endregion

        #region Type

        [Fact]
        public void User_Type_SetType_GetType()
        {
            var admin = new User()
            {
                Type = UserType.Admin
            };

            var customer = new User()
            {
                Type = UserType.Customer
            };
            
            Assert.Equal(UserType.Admin,admin.Type);
            Assert.Equal(UserType.Customer,customer.Type);
        }

        [Fact]
        public void User_Type_ShouldBeUserType()
        {
            var user = new User();
            Assert.True(user.Type is UserType);
        }

        [Fact]
        public void User_Type_NotNull()
        {
            var user = new User()
            {
                Type = UserType.Admin
            };
            Assert.NotNull(user.Type);
        }

        #endregion

        #region Password

        [Fact]
        public void User_Password_SetPassword_GetPassword()
        {
            var user = new User()
            {
                Password = ""
            };
            
            Assert.Equal("",user.Password);
        }

        [Fact]
        public void User_Password_ShouldBeString()
        {
            var user = new User()
            {
                Password = ""
            };
            
            Assert.True(user.Password is string);
        }
        
        [Fact]
        public void User_Password_CanBeNull()
        {
            var user = new User()
            {
                Password = null
            };
            
            Assert.Null(user.Password);
        }

        #endregion
    }
}