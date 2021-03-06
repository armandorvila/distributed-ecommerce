﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ArmandoShop.WebApplication.Models.Services;

namespace ArmandoShop.WebApplication.Models.Application.Access
{
    /// <summary>
    /// This class was adapted from Default MVC2 Project of VS10
    /// </summary>
    public class DelegateMembershipProvider : MembershipProvider
    {
        #region fields

        private DelegateUsersService usersService;

        private string applicationName;
        private bool enablePasswordReset;
        private bool enablePasswordRetrieval;
        private int maxInvalidPasswordAttempts;
        private int minRequiredNonAlphanumericCharacters;
        private int minRequiredPasswordLength;
        private int passwordAttemptWindow;
        private MembershipPasswordFormat passwordFormat;
        private string passwordStrengthRegularExpression;
        private bool requiresQuestionAndAnswer;
        private bool requiresUniqueEmail;

        #endregion

        public override void Initialize(string name,
                System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("Not config for Provider");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "XmlMembershipProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "WCF Service Membership Provider");
            }
            // Initialize the base class
            base.Initialize(name, config);
            this.usersService = new DelegateUsersService();

        }

        #region Properties

        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                this.applicationName = value;
            }
        }



        public override bool EnablePasswordReset
        {
            get
            {
                return enablePasswordReset;
            }

        }
        public override bool EnablePasswordRetrieval
        {
            get
            {
                return enablePasswordRetrieval;
            }

        }
        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return maxInvalidPasswordAttempts;
            }

        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return minRequiredNonAlphanumericCharacters;
            }

        }
        public override int MinRequiredPasswordLength
        {
            get
            {
                return minRequiredPasswordLength;
            }
        }
        public override int PasswordAttemptWindow
        {
            get
            {
                return passwordAttemptWindow;
            }

        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return passwordFormat;

            }
        }
        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return passwordStrengthRegularExpression;
            }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return requiresQuestionAndAnswer;
            }

        }
        public override bool RequiresUniqueEmail
        {
            get
            {
                return requiresUniqueEmail;
            }

        }

        #endregion

        #region Overriden Methods

       
        public override MembershipUser CreateUser(string username, 
            string password, string email, string name, 
            string surname, bool isApproved, object idProfile, 
            out MembershipCreateStatus status)
        {
            User user = new User();
            user.username = username;
            user.password = password;
           

            usersService.NewUser(user);
            status = MembershipCreateStatus.Success;

            return this.createFromUser(user);
        }


        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            
            return this.createFromUser(this.usersService.Login(username,""));

        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            MembershipUser user = new MembershipUser(base.Name, "", null, "", "", "",
                 true, false, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);

            return user;
        }

       
        public override bool ValidateUser(string username, string password)
        {
            User user = usersService.Login(username,password);
            if (user == null)
                return false;
            return true;
        }
        #endregion

        private MembershipUser createFromUser(User user)
        {
            MembershipUser muser = new MembershipUser(base.Name, user.username, null, "", "", "",
                 true, false, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);

            return muser;
        }

        #region Unimplemented methods

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }


        #endregion

    }

}