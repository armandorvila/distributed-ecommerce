using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ArmandoShop.WebApplication.Models.Application.Access
{

    /// <summary>
    /// This class was adapted from Default MVC2 Project of VS10
    /// </summary>
    public class AccessMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccessMembershipService()
            : this(null)
        {
        }

        public AccessMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("El valor no puede ser NULL ni estar vacío.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("El valor no puede ser NULL ni estar vacío.", "password");

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string username, string password,long idProfile)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentException("El valor no puede ser NULL ni estar vacío.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("El valor no puede ser NULL ni estar vacío.", "password");       

            MembershipCreateStatus status;
            _provider.CreateUser(username, password, "", null, null, true, idProfile, out status);
            return status;
        }

    }
}