using API_Layer.DTOs;
using DataAccess_Layer.Entities.Logs;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core_Layer.Core_Classes.Sessions
{
    public class clsUserSession : Repository<eUsersSessionsDA>
    {


        public clsUserSession()
        {
            
        }

        internal clsUserSession(eUsersSessionsDA? eSession)
        {
            base.BaseObject = eSession;
            
        }

        public static int Session_Timeout_Age_InDays 
        {
            get 
            {
                return 90;
            }
            
            set
            {
                Session_Timeout_Age_InDays = value;
            } 
        }



        public enum enSessionValidationResult
        {
            eSession_NotExist,
            eSession_NotValid,
            eSession_Timout,
            eSession_Valid,

            eSession_User_NotMatch,
            eUser_HasNoSession

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



        /// <summary>
        /// Validates the session by the session ID.
        /// </summary>
        /// <param name="SessionID"></param>
        /// <returns>
        /// <par>enum of enSessionValidationResult.</par>
        /// <para>'eSession_NotExist' if the session does not exist in the database.</para>
        /// <para>'eSession_NotValid' if the session exists in the database but is not valid.</para>
        /// <para>'eSession_Timout' if the session exists in the database but the it's timespan reached the max.</para>
        /// <para>'eSession_Valid' if the session exists in the database and valid.</para>
        /// </returns>
        public static enSessionValidationResult ValidateSession(string SessionID, int UserID)
        {
            clsUserSession session = new clsUserSession(GetItem(SessionID));

            if (session == null || session.BaseObject == null)           
                return enSessionValidationResult.eSession_NotExist;
            
            if (!session.BaseObject.IsValid)
                return enSessionValidationResult.eSession_NotValid;


            TimeSpan difference = DateTime.Now - session.BaseObject.LasAct_TimeStamp;

            if (difference.Days > Session_Timeout_Age_InDays)           
                return enSessionValidationResult.eSession_Timout;

            clsUserSession? UserSession = clsUserSession.GetSession(UserID);


            if (UserSession == null || UserSession.BaseObject == null)
                return enSessionValidationResult.eUser_HasNoSession;


            if (string.IsNullOrEmpty(UserSession.BaseObject.SessionID))
                return enSessionValidationResult.eUser_HasNoSession;


            if (UserSession.BaseObject.SessionID != SessionID)
                return enSessionValidationResult.eSession_User_NotMatch;        

            return enSessionValidationResult.eSession_Valid;


        }



        public static clsUserSession? GetSession(int UserID)
        {
            if (UserID <= 0)
                return null;

           return new clsUserSession(context.UsersSessions.SingleOrDefault(s => s.UserID == UserID && s.IsValid));
        }


        protected override void InitBaseObject()
        {
            this.BaseObject = new eUsersSessionsDA() { SessionID = string.Empty, 
                UserID = -1, LasAct_TimeStamp = DateTime.MinValue,
                IsValid = false };
        }


    }
}
