using API_Layer.DTOs;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Core_Classes.Users
{
    public static class clsLoginValidation
    {

        public enum enLoginResult
        {
            eWrongUsername,
            eWrongPassword,
            eCorrectInfo,
            NULL
        }

        public struct stLoginResult
        {
            public enLoginResult enLoginResult { get; set; }

            public eUserDA? userInfo { get; set; }


            public stLoginResult()
            {
                userInfo = eUserDA.InitClass();
                enLoginResult = enLoginResult.NULL;
            }


            public stLoginResult(enLoginResult enLoginResult, eUserDA? userInfo)
            {
                this.userInfo = userInfo;
                this.enLoginResult = enLoginResult;
            }
        }







        /// <summary>
        /// Validates the user login info by checking the username first, if matches then it validatest he password,
        /// if they match it returns the user object.
        /// </summary>
        /// <param name="dtoLoginUser"></param>
        /// <returns>
        /// A loginResult object that contains :
        ///<para>1-enLoginResult.eWrongUsername if the username is wrong.</para>
        ///<para>2-enLoginResult.eWrongPassword if the password is wrong.</para>
        ///<para>3-The user object if the info matches.</para>  
        ///<para>4-The user session ID.</para> 
        /// </returns>
        public async static Task<stLoginResult> ValidateUserInfoAsync(UsersDTOs.LoginUserDTO dtoLoginUser)
        {
            stLoginResult loginResult = new stLoginResult();

            eUserDA? user = await eUserDA.GetUserInfoAsync(dtoLoginUser.Username);

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
            loginResult.userInfo = user;




           





            return loginResult;
        }
    }
}
