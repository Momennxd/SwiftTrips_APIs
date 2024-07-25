using API_Layer.DTOs;
using DataAccess_Layer.Entities.Logs;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Core_Classes.Sessions
{
    public class clsUserSession : Repository<eUsersSessionsDA>
    {


        public clsUserSession()
        {
            
        }



        public clsUserSession(string SessionID, int UserID, DateTime LasAct_TimeStamp,
            bool IsValid, byte? Invalid_Reason)
        {
            base.BaseObject = new eUsersSessionsDA()
            {
                SessionID = SessionID,
                UserID = UserID,
                LasAct_TimeStamp = LasAct_TimeStamp,
                IsValid = IsValid,
                Invalid_Reason = Invalid_Reason
            };

        }




        /// <summary>
        /// generates a session ID as a string (GUID)
        /// </summary>
        /// <returns></returns>
        public static string GenSessionID()
        {
            return  Guid.NewGuid().ToString(); // Generate a new GUID as the session ID
        }



        protected override void InitBaseObject()
        {
            this.BaseObject = new eUsersSessionsDA() { SessionID = string.Empty, 
                UserID = -1, LasAct_TimeStamp = DateTime.MinValue,
                IsValid = false };
        }


    }
}
