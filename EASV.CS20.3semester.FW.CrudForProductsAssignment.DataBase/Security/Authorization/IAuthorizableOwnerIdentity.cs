namespace EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authorization
{
    public interface IAuthorizableOwnerIdentity
    {
        long getAuthorizedOwnerId();

        string getAuthorizedOwnerName();
    }
}