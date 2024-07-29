using API_Layer.DTOs;
using Core_Layer.Core_Classes.Sessions;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Core_Classes.Users
{
    public class clsUserValidation
    {

        public enum enLoginResult
        {
            eWrongUsername,
            eWrongPassword,
            eCorrectInfo,
            NULL,
            SessionFailed
        }

        public struct stLoginResult
        {
            public enLoginResult enLoginResult { get; set; }

            public clsUser? userInfo { get; set; }

            public string sessionID { get; set; }

            public stLoginResult()
            {
                userInfo = new clsUser();
                enLoginResult = enLoginResult.NULL;
                sessionID = "";
            }


            public stLoginResult(enLoginResult enLoginResult, clsUser? userInfo, string sessionID)
            {
                this.userInfo = userInfo;
                this.enLoginResult = enLoginResult;
                this.sessionID = sessionID;
            }
        }


       

      




        /// <summary>
        /// Valdidates the user login info by checking the username first, if matches then it validatest he password,
        /// if they match it returns the user object.
        /// </summary>
        /// <param name="dtoLoginUser"></param>
        /// <returns>
        ///<para>1-enLoginResult.eWrongUsername if the username is wrong.</para>
        ///<para>2-enLoginResult.eWrongPassword if the password is wrong.</para>
        ///<para>3-The user object if the info matches.</para>  
        /// </returns>
        public static stLoginResult ValidateUserInfo(UsersDTOs.LoginUserDTO dtoLoginUser)
        {
            stLoginResult loginResult = new stLoginResult();

            User? user = clsUser.GetUserInfo(dtoLoginUser.Username);

            if (user == null)
            {
                loginResult.enLoginResult = enLoginResult.eWrongUsername;
                loginResult.userInfo = null;
                return loginResult;
            }

            if (user.Password != dtoLoginUser.Password)
            {
                loginResult.enLoginResult = enLoginResult.eWrongPassword;
                loginResult.userInfo = null;
                return loginResult;

            }

            loginResult.enLoginResult = enLoginResult.eCorrectInfo;
            loginResult.userInfo.BaseObject = user;




            #region create session.

            clsUserSession session = new clsUserSession(clsUserSession.GenSessionID(),loginResult.userInfo.BaseObject.UserID,
                DateTime.Now, true, null);


            clsUserSession.AddItem(session.BaseObject);

            if (session.BaseObject == null || string.IsNullOrEmpty(session.BaseObject.SessionID))
                return new stLoginResult(enLoginResult.SessionFailed, null, string.Empty);



            loginResult.sessionID = session.BaseObject.SessionID;

            #endregion





            return loginResult;
        }
    }
}
