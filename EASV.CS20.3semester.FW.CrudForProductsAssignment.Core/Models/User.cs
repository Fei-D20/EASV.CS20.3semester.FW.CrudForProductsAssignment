namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserType Type { get; set; }
        public string? Password { get; set; }
    }
}