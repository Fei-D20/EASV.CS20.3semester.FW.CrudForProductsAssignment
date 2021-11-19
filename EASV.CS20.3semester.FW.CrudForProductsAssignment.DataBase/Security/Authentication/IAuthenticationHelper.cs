using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authentication
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] stroedHash, byte[] storedSalt);
        string GenerateToken(User user);
    }
}