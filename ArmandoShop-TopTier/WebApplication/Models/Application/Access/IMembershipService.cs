using System.Web.Security;

namespace ArmandoShop.WebApplication.Models.Application.Access
{
    /// <summary>
    /// This Interface was adapted from Default MVC2 Project of VS10
    /// </summary>
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        
        MembershipCreateStatus CreateUser(string userName,string password,long idProfile);
        
    }

}