using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserType Type { get; set; }
        public string? Password { get; set; }
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}