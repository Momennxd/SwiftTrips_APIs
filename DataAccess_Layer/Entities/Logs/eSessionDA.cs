using Core_Layer.AppDbContext;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Logs
{
    public class eSessionDA : Repository<eSessionDA>
    {


        //properties

        [Key]
        public string SessionID { get; set; }


        public required int UserID { get; set; }


        public required DateTime LasAct_TimeStamp { get; set; }


        public required bool IsValid { get; set; }

        public byte? Invalid_Reason { get; set; }






        //logic


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


        /// <summary>
        /// Generates a session ID as a string (GUID)
        /// </summary>
        /// <returns></returns>
        public static string GenSessionID()
        {
            return Guid.NewGuid().ToString(); // Generate a new GUID as the session ID
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
        /// <para>'eUser_HasNoSession' if the user has no session in the database.</para>
        /// <para>'eSession_Valid' if the session exists in the database and valid.</para>
        /// </returns>
        public async static Task<enSessionValidationResult> ValidateSessionAsync(string SessionID, int UserID)
        {
            eSessionDA? session = await eSessionDA.FindAsync(SessionID);

            if (session == null)
                return enSessionValidationResult.eSession_NotExist;

            if (!session.IsValid)
                return enSessionValidationResult.eSession_NotValid;


            TimeSpan difference = DateTime.Now - session.LasAct_TimeStamp;

            if (difference.Days > Session_Timeout_Age_InDays)
                return enSessionValidationResult.eSession_Timout;

            eSessionDA? UserSession = await GetSessionAsync(UserID);


            if (UserSession == null)
                return enSessionValidationResult.eUser_HasNoSession;


            if (string.IsNullOrEmpty(UserSession.SessionID))
                return enSessionValidationResult.eUser_HasNoSession;


            if (UserSession.SessionID != SessionID)
                return enSessionValidationResult.eSession_User_NotMatch;

            return enSessionValidationResult.eSession_Valid;


        }



        public async static Task<eSessionDA?> GetSessionAsync(int UserID)
        {
            if (UserID <= 0)
                return null;
            try
            {
                using(AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {
                    return await context.UsersSessions.FirstOrDefaultAsync(s => s.UserID == UserID && s.IsValid);
                }
            }
            catch (Exception ex) { return null; }
        }



        public static eSessionDA CreateSession(int UserID)
        {
            return new eSessionDA()
            {
                UserID = UserID,
                SessionID = GenSessionID(),
                LasAct_TimeStamp = DateTime.Now,
                IsValid = true,
                Invalid_Reason = null
            };

        }



    }
}
